using System.Collections.Generic;

[System.Serializable]

public class PlayerData
{
    public int coins;
    //public float timerRemaining;
    //public string currentOrderName;
    //public List<string> selectedIngredients;


    public PlayerData(int coins)
    {
        this.coins = coins;
    }

    /*
    public PlayerData(int coins, float timer, string orderName, List<string> selectedIngredients) 
    {
        this.coins = coins;
        this.timerRemaining = timer;
        this.currentOrderName = orderName;
        this.selectedIngredients = selectedIngredients;
    }
    */
}
