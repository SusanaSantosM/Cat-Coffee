using UnityEngine;

[CreateAssetMenu(fileName = "NuevaComida", menuName = "Menu/Comida")]
public class ComidaPedido : MenuItem
{
    [Header("Preparación de Comida")]
    public bool requiresPlate;
    public bool withIceCream;
    public IceCreamf iceCreamFlavor;
}

public enum IceCreamf
{
    Ninguno,
    Chocolate,
    Vanilla
}
