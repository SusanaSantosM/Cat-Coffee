using UnityEngine;

[CreateAssetMenu(fileName = "NuevoMenu", menuName = "Configuración/Menú de Pedidos")]
public class ConfiguraciónScriptableObject : ScriptableObject
{
    [System.Serializable]
    public struct ItemMenu
    {
        public string nombre;
        public Sprite sprite;
        public float precio; 
    }

    public ItemMenu[] bebidas;
    public ItemMenu[] comidas; // Para futura expansión
}
