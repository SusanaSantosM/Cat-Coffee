using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("UI Elements")]
    public TextMeshProUGUI orderText, timerText, coinText, feedbackText;
    public TextMeshProUGUI requiredIngredientsText;

    [Header("Customer Settings")]
    public Transform customerSpawnPoint;
    public GameObject[] customerPrefabs; // Prefabs de clientes
    public List<DrinkOrder> orderList;   // Bebidas

    [Header("Audio Settings")]
    public AudioSource backgroundMusic; // AudioSource

    [Header("UI Buttons")]
    public Button[] interactionButtons; // botones interactivos

    private int lastOrderIndex = -1;

    private GameObject currentCustomer;
    private DrinkOrder currentOrder;
    private List<string> selectedIngredients = new List<string>();

    [SerializeField] private float timer = 60f;
    private int coins = 0;
    private bool gameRunning = true;

    private PlayerData playerData;

    void Start()
    {
        // Sistema de guardado
        playerData = SaveSystem.Load();
        coins = playerData.coins;
        //timer = playerData.timerRemaining;
        coinText.text = "Coins: " + coins;

        SpawnNextCustomer();
    }

    void Update()
    {
        if (!gameRunning) return;

        timer -= Time.deltaTime;
        timerText.text = "Time: " + Mathf.CeilToInt(timer);

        if (timer <= 0)
        {
            gameRunning = false;
            SaveGame();
            orderText.text = "Time's up!";
            feedbackText.text = "";

            // Detener la música
            if (backgroundMusic != null && backgroundMusic.isPlaying)
            {
                backgroundMusic.Stop();
            }

            // Desactivar todos los botones
            foreach (Button btn in interactionButtons)
            {
                btn.interactable = false;
            }

            if (currentCustomer != null) Destroy(currentCustomer);
        }
    }

    public void AddIngredient(string ingredient)
    {
        selectedIngredients.Add(ingredient);

        if (currentOrder.ingredients.Contains(ingredient))
        {
            Debug.Log($"{ingredient} added — ✅ Correct (in order)");
        }
        else
        {
            Debug.Log($"{ingredient} added — ❌ Incorrect (not in order)");
        }
    }



    public void SubmitDrink()
    {
        if (CompareLists(currentOrder.ingredients, selectedIngredients))
        {
            coins = coins + 5;
            coinText.text = "Coins: " + coins;
            Debug.Log("✅ Drink submitted — Correct match!");
            Destroy(currentCustomer);
            SpawnNextCustomer();
        }
        else
        {
            Debug.Log("❌ Drink submitted — Ingredients incorrect.");
        }

        selectedIngredients.Clear();
    }



    bool CompareLists(List<string> a, List<string> b)
    {
        if (a.Count != b.Count) return false;

        // Copia las listas para evitar modificar datos originales
        List<string> tempA = new List<string>(a);
        List<string> tempB = new List<string>(b);

        tempA.Sort();
        tempB.Sort();

        for (int i = 0; i < tempA.Count; i++)
        {
            if (tempA[i] != tempB[i]) return false;
        }

        return true;
    }


    void SpawnNextCustomer()
    {
        if (currentCustomer != null)
        {
            Destroy(currentCustomer);
        }

        if (customerPrefabs.Length == 0)
        {
            Debug.LogWarning("❌ No customer prefabs assigned in GameManager!");
            return;
        }

        int randCustomer = Random.Range(0, customerPrefabs.Length);

        if (customerPrefabs[randCustomer] == null)
        {
            Debug.LogWarning($"❌ Customer prefab at index {randCustomer} is null!");
            return;
        }

        currentCustomer = Instantiate(customerPrefabs[randCustomer], customerSpawnPoint.position, Quaternion.identity);

        // Orden lógico
        int randOrder;
        do
        {
            randOrder = Random.Range(0, orderList.Count);
        } while (orderList.Count > 1 && randOrder == lastOrderIndex);

        lastOrderIndex = randOrder;
        currentOrder = orderList[randOrder];

        orderText.text = $"Order: {currentOrder.drinkName}";
        Debug.Log($"🧾 New Order: {currentOrder.drinkName}");

        // Ingredientes UI
        string ingredientsList = "Needed:\n";
        foreach (string item in currentOrder.ingredients)
        {
            ingredientsList += " - " + item + "\n";
        }

        requiredIngredientsText.text = ingredientsList;
    }


    public void SaveGame()
    {
        /*
        PlayerData data = new PlayerData(
            coins,
            timer,
            currentOrder != null ? currentOrder.drinkName : "",
            new List<string>(selectedIngredients)
        );*/

        PlayerData data = new PlayerData(
            coins
        );

        SaveSystem.Save(data);
    }
}
