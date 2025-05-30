using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

public class ClienteComportamiento : MonoBehaviour
{
    public enum EstadoEmocional { Neutral, Feliz, Molesto }

    [Header("Configuraci�n")]
    public float duracionEmocion = 2f;
    public float duracionAnimacionSalirFeliz = 1.5f; 
    public float duracionAnimacionSalirTriste = 1.5f;

    [Header("Referencias de Pedidos")]  //Al scriptable object
    public Configuraci�nScriptableObject configuracionMenu;

    [Header("Burbuja de Di�logo")]
    public GameObject burbujaDialogoSR;
    public Image iconoBebida;

    private SpriteRenderer spriteRnder;
    private Animator animator;
    private EstadoEmocional estadoActual;
    private Pedido pedidoActual;


    void Awake()
    {
        spriteRnder = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        //Cambio de animo del cliente
        CambiarEmocion(EstadoEmocional.Neutral);
    }

    public void EstablecerPedido(Pedido nuevoPedido) 
    {
        pedidoActual = nuevoPedido;
        MostrarIconoPedido();
    }

    private void MostrarIconoPedido()
    {
        if (configuracionMenu == null)
        {
            Debug.LogError("�Configuraci�n de Men� no asignada en ClienteComportamiento! Asigna tu ScriptableObject.");
            return;
        }

        if (pedidoActual == null)
        {
            Debug.LogError("�No hay pedido actual asignado!");
            return;
        }

        // Busca el ItemMenu correspondiente al tipo de bebida del pedido actual
        Configuraci�nScriptableObject.ItemMenu itemPedido = configuracionMenu.bebidas
            .FirstOrDefault(item => item.nombre == pedidoActual.tipoBebida.ToString());
        // Suponemos que el nombre del enum TipoBebida coincide con el 'nombre' del ItemMenu

        if (itemPedido.sprite != null)
        {
            if (iconoBebida != null)
            {
                iconoBebida.sprite = itemPedido.sprite;
                burbujaDialogoSR.gameObject.SetActive(true); // Activa la burbuja si estaba oculta
                iconoBebida.gameObject.SetActive(true); // Aseg�rate de que el icono tambi�n est� activo
            }
            else
            {
                Debug.LogWarning("No se ha asignado un SpriteRenderer para el icono de la burbuja en el ClienteComportamiento.");
            }
        }

    }


    // Opcional: Ocultar la burbuja de di�logo cuando el pedido se ha entregado
    public void OcultarBurbujaDeDialogo()
    {
        if (burbujaDialogoSR != null)
        {
            burbujaDialogoSR.gameObject.SetActive(false);
        }
        if (iconoBebida != null)
        {
            iconoBebida.gameObject.SetActive(false);
        }
    }

    public void RecibirBebida(Pedido.TipoBebida bebida, Pedido.TipoEnvase envase)
    {
        if (pedidoActual == null)
        {
            Debug.LogWarning("El cliente no tiene un pedido asignado.");
            CambiarEmocion(EstadoEmocional.Molesto);
            // Si no hay pedido, se va molesto
            Invoke("IniciarSalida", duracionEmocion);
            return;
        }

        bool esCorrecto = LevelManager.Instance.Pedidos.VerificarPedido(pedidoActual, bebida, envase);

        if (esCorrecto)
        {
            CambiarEmocion(EstadoEmocional.Feliz);
            // Obtener el precio del ScriptableObject
            Configuraci�nScriptableObject.ItemMenu itemPedido = configuracionMenu.bebidas
                .FirstOrDefault(item => item.nombre == pedidoActual.tipoBebida.ToString());

            if (itemPedido.precio > 0.0) // Precio en float
            {
                LevelManager.Instance.Puntuacion.AnadirGanancia(itemPedido.precio);
            }
            else
            {
                Debug.LogError($"Precio no definido para la bebida: {pedidoActual.tipoBebida} en la configuraci�n del men�.");
            }
            OcultarBurbujaDeDialogo(); 
            // Llama a la animaci�n de salida feliz del cliente
            Invoke("IniciarSalidaFeliz", duracionEmocion);
        }
        else
        {
            CambiarEmocion(EstadoEmocional.Molesto);
            OcultarBurbujaDeDialogo();
            // Llama a la animaci�n de salida triste del cliente
            Invoke("IniciarSalidaMolesto", duracionEmocion);
        }

        Invoke("IniciarSalida", duracionEmocion);
    }

    void CambiarEmocion(EstadoEmocional nuevoEstado)
    {
        estadoActual = nuevoEstado;

        switch (estadoActual)
        {
            case EstadoEmocional.Neutral:
                animator.SetTrigger("SetNeutral");
                break;
            case EstadoEmocional.Feliz:
                animator.SetTrigger("SetFeliz");
                break;
            case EstadoEmocional.Molesto:
                animator.SetTrigger("SetMolesto");
                break;
        }
    }

    // M�todo para iniciar la animaci�n de salida feliz
    void IniciarSalidaFeliz()
    {
        animator.SetTrigger("SetSalirFeliz");
        Destroy(gameObject, duracionAnimacionSalirFeliz);
    }

    // Nuevo m�todo para iniciar la animaci�n de salida triste
    void IniciarSalidaTriste()
    {
        animator.SetTrigger("SetSalirMolesto");
        Destroy(gameObject, duracionAnimacionSalirTriste);
    }

    /*
    void IniciarSalida()
    {
        animator.SetTrigger("SetSalir");
        Destroy(gameObject, duracionAnimacionSalida);
    }*/
}
