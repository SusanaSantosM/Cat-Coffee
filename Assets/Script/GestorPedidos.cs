using UnityEngine;

public class GestorPedidos
{
    public bool VerificarPedido(Pedido pedidoCliente, Pedido.TipoBebida bebidaEntregada, Pedido.TipoEnvase envaseEntregado)
    {
        if (pedidoCliente == null) 
        {
            Debug.Log("Verificamos pedido: No hay pedido para verificar");
            return false;
        }
        return pedidoCliente.tipoBebida == bebidaEntregada && pedidoCliente.tipoEnvase == envaseEntregado;
    }

    // Puedes añadir un constructor si necesitas inicializar algo al crear una instancia
    public GestorPedidos()
    {
        Debug.Log("GestorPedidos inicializado.");
    }
}
