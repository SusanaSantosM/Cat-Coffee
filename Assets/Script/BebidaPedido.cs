using UnityEngine;

[CreateAssetMenu(fileName = "NuevaBebida", menuName = "Menu/Bebida")]
public class BebidaPedido : MenuItem
{
    [Header("Preparación de Bebida")]
    public bool withCoffee;
    public bool withMilk;
    public bool withHotWatter;
    public bool withColdWatter;
    public bool withIceCubes;
    public bool withIceCreamm;
    public IceCream icreCreamFlavorr;
 }

public enum IceCream
{
    Ninguno,
    Chocolate,
    Vainilla
}



