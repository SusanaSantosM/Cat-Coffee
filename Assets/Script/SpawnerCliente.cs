using UnityEngine;

public class SpawnerCliente : MonoBehaviour
{
    public GameObject[] prefabsClientes; // Arrastra los prefabs de clientes
    public Transform[] SpawnPoint;
    public float timeToTakeOrder = 60f;

   /* void Start()
    {
        InvokeRepeating("SpawnearCliente", 2f, timeToTakeOrder);
    }

    void SpawnearCliente()
    {
        int clienteIndex = Random.Range(0, prefabsClientes.Length);
        int puntoIndex = Random.Range(0, SpawnPoint.Length);

        Instantiate(prefabsClientes[clienteIndex],
                   SpawnPoint[puntoIndex].position,
                   Quaternion.identity);
    }
   */
}
