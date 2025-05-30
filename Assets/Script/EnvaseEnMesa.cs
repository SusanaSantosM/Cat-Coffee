using UnityEngine;

public class EnvaseEnMesa : MonoBehaviour
{
    public enum TipoEnvase {Ninguno, Taza, VasoCh, VasoGr, Plato}
    public TipoEnvase envase = TipoEnvase.Ninguno;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = null;  //Inicia sin ningun envase
    }

    public void ReiniciarEnvase() 
    {
        spriteRenderer.sprite = null;
        envase = TipoEnvase.Ninguno;
    }

}
