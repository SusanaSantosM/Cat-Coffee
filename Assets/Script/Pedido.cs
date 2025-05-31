using UnityEngine;


// Permite que se vea en el Inspector si es parte de otra clase MonoBehaviour
[System.Serializable] 
public class Pedido
{
    // Tipos de bebida que puedes tener
    public enum TipoBebida
    {
        Espresso,
        Americano,
        CafeConLeche,
        CafeHelado,
        CafeConLecheHelado,
        Afogato
    }

    // Tipos de envase si son relevantes para tu juego
    public enum TipoEnvase
    {
        Taza,
        Vaso,
        ParaLlevar
    }

    public TipoBebida tipoBebida;
    public TipoEnvase tipoEnvase;
}
