using UnityEngine;

public class TipoDeBebidas : MonoBehaviour
{
    public enum Bebida
    {
        Vacio,
        Espresso,
        Americano,
        CafeConLeche,
        AmericanoFrio,
        CafeLecheFrio,
        Afogato
    }

    [System.Serializable]
    public class EstadoEnvase
    {
        public Sprite vacio;
        public Sprite espresso;
        public Sprite conCafe;
        public Sprite conAgua;
        public Sprite conHielo;
        public Sprite conLeche;
        public Sprite conHelado;
    }

    [Header("Configuración")]
    public Bebida tipoBebida;
    public int tipoEnvaseActual; // 0:Taza, 1:Vaso chico, 2:Vaso grande
    public EstadoEnvase[] estadosPorTipo; // Asigna en Inspector [0]=Taza, [1]=Vaso chico, etc.

    private SpriteRenderer spriteRenderer;
    private Bebida bebidaActual;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        ResetearEnvase();
    }

    public void IniciarPreparacion(Bebida bebida)
    {
        bebidaActual = bebida;
        ActualizarSprite(1); // Empieza con café (estado 1)
    }

    public void AgregarIngrediente(int estado)
    {
        ActualizarSprite(estado);
    }

    private void ActualizarSprite(int estado)
    {
        switch (estado)
        {
            case 0: spriteRenderer.sprite = estadosPorTipo[tipoEnvaseActual].vacio; break;
            case 1: spriteRenderer.sprite = estadosPorTipo[tipoEnvaseActual].espresso; break;
            case 2: spriteRenderer.sprite = estadosPorTipo[tipoEnvaseActual].conCafe; break;
            case 3: spriteRenderer.sprite = estadosPorTipo[tipoEnvaseActual].conAgua; break;
            case 4: spriteRenderer.sprite = estadosPorTipo[tipoEnvaseActual].conLeche; break;
            case 5: spriteRenderer.sprite = estadosPorTipo[tipoEnvaseActual].conHielo; break;
            case 6: spriteRenderer.sprite = estadosPorTipo[tipoEnvaseActual].conHelado; break;

        }
    }

    public void ResetearEnvase()
    {
        bebidaActual = Bebida.Vacio;
        ActualizarSprite(0);
    }
}