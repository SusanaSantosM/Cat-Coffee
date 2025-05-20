using UnityEngine;

public class MaquinaCafe : MonoBehaviour
{
    public Transform puntoDeColocacion; // Arrastra el Empty GameObject hijo aquí

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Si un envase entra en la zona de la máquina, asignarle el punto de colocación
        if (other.CompareTag("recipiente"))
        {
            other.GetComponent<DragAndDrop>().SetPuntoDeColocacion(puntoDeColocacion);
        }
    }
}
