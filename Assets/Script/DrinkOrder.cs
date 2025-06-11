using System.Collections.Generic;

[System.Serializable]
public class DrinkOrder
{
    public string drinkName;
    public List<string> ingredients;

    public DrinkOrder(string name, List<string> ingredients)
    {
        drinkName = name;
        this.ingredients = ingredients;
    }
}
