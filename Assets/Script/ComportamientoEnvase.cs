using UnityEngine;

public class ComportamientoEnvase : MonoBehaviour
{
    [System.Serializable]
    public class EstadoEnvase 
    {   
        // Estado de los envases
        public Sprite vacio;        //0
        public Sprite conCafe;      //1
        public Sprite conAgua;      //2
        public Sprite conHielo;     //3
        public Sprite conLeche;     //4
    }

    public EstadoEnvase[] estadosPorTipo;    //Tipo de envase
    public int tipoEnvaseActual;    // 0:Taza, 1:Vaso chico, 2:Vaso grande
    private SpriteRenderer spriteEnvase;
    private int estadoActual = 0;

    private void Start()
    {
        spriteEnvase = GetComponent<SpriteRenderer>();

    }

    public void CambiarEstados(int nuevoEstado) 
    {
        estadoActual = nuevoEstado;

    }

    private void ActualizarSprite() 
    {   
        // Actualizamos los estado del sprite seg�n la bebida
        spriteEnvase.sprite = estadosPorTipo[tipoEnvaseActual].vacio;

        //CAf� espresso

        //Caf� Americano

        //Caf� con leche

        //Americano frio

        //Caf� con leche frio

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {   
        if (collision.CompareTag("MaqCafe") && estadoActual == 0)
        {
            CambiarEstados(1);      //Con caf�
        }

        // Seg�n la bebida

        // Caf� americano
        else if (collision.CompareTag("AguaCaliente") && estadoActual == 1)
        {
            CambiarEstados(2);      //Con agua caliente
        }

    }
}
