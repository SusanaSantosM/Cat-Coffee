using UnityEngine;

public class SpawnerCliente : MonoBehaviour
{
    public GameObject[] prefabsClientes; // Arrastra tus prefabs de clientes
    public Transform[] puntosSpawn;
    public float tiempoEntreClientes = 30f;

    void Start()
    {
        InvokeRepeating("SpawnearCliente", 2f, tiempoEntreClientes);
    }

        int clienteIndex = Random.Range(0, prefabsClientes.Length);
        int puntoIndex = Random.Range(0, puntosSpawn.Length);

        GameObject newClientObj = Instantiate(prefabsClientes[clienteIndex],
                                               SpawnPoint[puntoIndex].position,
                   Quaternion.identity);
    }
}
