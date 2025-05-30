using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    // Implementación del patrón Singleton para LevelManager
    public static LevelManager Instance { get; private set; }

    // Instancias de tus gestores
    public GestorPedidos Pedidos { get; private set; }
    public GestorPuntuacion Puntuacion { get; private set; }


    public void BotonStart()
    {   
        // PAra ir a la escena del juego
        SceneManager.LoadScene(1);
    }


    void Awake()
    {
        // Asegura que solo haya una instancia de LevelManager
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            // Opcional: para que el gestor persista entre escenas
            // DontDestroyOnLoad(gameObject);

            // Inicializa tus gestores
            Pedidos = new GestorPedidos();
            Puntuacion = new GestorPuntuacion();
        }
    }


    public void BotonEnd()
    {
        // Si Android
        // Muestra un panel de confirmación (ej: "¿Seguro que quieres salir?")
        //ConfirmPanel.SetActive(true); --> Ahi metes el if
        Application.Quit();
        Debug.Log("Salir del juego");
        
        // Si es WEB
        Debug.Log("No se puede cerrar en WebGL. Por favor, cierra la pestaña manualmente.");
        // Redirigir a una URL externa (ej: tu web personal)
    }




}
