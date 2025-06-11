using UnityEngine;

//[CreateAssetMenu(fileName = "NuevoPedido", menuName = "Pedidos/Nuevo Pedido")]
public class MenuItem : ScriptableObject
{
    
    public string nombreItem;
    public Sprite iconoItem;    //Sprite del pedido
    public float precio; 
    
}
