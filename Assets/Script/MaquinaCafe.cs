using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class MaquinaCafe : MonoBehaviour, IPointerDownHandler
{
    [Header("Sprites M�quina")]
    public Sprite maqNormal;
    public Sprite maqExtrayendo;
    public Sprite maqCalentandoLeche;
    //public Sprite envaseGConCafe;

    /*[Header("Sprite de envase")]
    public Transform envaseGenerico;    // Arrastra el objeto del envase
    public Transform jarra;             // Jarra con leche
    public Sprite envaseGenericoCafe;*/

    [Header("Configuraci�n")]
    public float tiempoPreparacion = 2f;
    public Transform puntoDeColocacion; // Arrastra el Empty GameObject hijo aqu�


    private SpriteRenderer spriteMaquina;
    private GameObject envaseActual;
    private bool preparando = false;


    void Start()
    {
        spriteMaquina = GetComponent<SpriteRenderer>();
        if (spriteMaquina == null)
        {
            Debug.LogError("Error: No se encontr� el componente SpriteRenderer en MaquinaCafe.", this);
        }
        spriteMaquina.sprite = maqNormal;   //Maq de caf� normal
    }


    // Detecta cuando hacen clic en la m�quina
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("�Clic en la m�quina de caf�!");
        if (envaseActual !=null && !preparando) 
        {
            StartCoroutine(PrepararCafe());
        }

        envaseActual.GetComponent<TipoDeBebidas>().AgregarIngrediente(1);

    }


    // Llamado desde el script del envase cuando se coloca
    public void ColocarEnvase(GameObject envase)
    {
        envaseActual = envase;
        envaseActual.transform.position = puntoDeColocacion.position;
        // Se desactiva por un momento el arrastre del objeto
        envaseActual.GetComponent<Collider2D>().enabled = false;
    }


    IEnumerator PrepararCafe()
    {
        preparando = true;

        // Cambia sprite m�quina
        spriteMaquina.sprite = maqExtrayendo;

        // Esperar el tiempo de preparaci�n
        yield return new WaitForSeconds(tiempoPreparacion);

        // Seg�nla bebida

        // Espresso
        if (envaseActual != null)
        {
            // Preparar bebida
            var tipoBebidas = envaseActual.GetComponent<TipoDeBebidas>();
            if (tipoBebidas != null)
            {
                tipoBebidas.IniciarPreparacion(TipoDeBebidas.Bebida.Espresso);
            }
            else
            {
                Debug.LogError("El envase no tiene componente TipoDeBebidas");
            }
        }
        // Reactivar arrastre
        envaseActual.GetComponent<Collider2D>().enabled = true;


        // Reset m�quina
        spriteMaquina.sprite = maqNormal;
        preparando = false;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        // Si un envase entra en la zona de la m�quina, asignarle el punto de colocaci�n
        if (other.CompareTag("Envase"))
        {
            other.GetComponent<DragAndDrop>().SetPuntoDeColocacion(puntoDeColocacion);
        }

    }

    
}
