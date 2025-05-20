using UnityEngine;

public class MaquinaCafe : MonoBehaviour
{
    public Transform puntoDeColocacion; // Arrastra el Empty GameObject hijo aqu�

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Si un envase entra en la zona de la m�quina, asignarle el punto de colocaci�n
        if (other.CompareTag("recipiente"))
        {
            other.GetComponent<DragAndDrop>().SetPuntoDeColocacion(puntoDeColocacion);
        }
    }
}
