using UnityEngine;
using UnityEngine.SceneManagement;

public class LvelManager : MonoBehaviour
{
    // Métodos para ir a cada escena
    public void BotonStart()
    {
        SceneManager.LoadScene(1);
    }


    public void BotonEnd()
    {
        // Si Android
        // Muestra un panel de confirmación (ej: "¿Seguro que quieres salir?")
        //ConfirmPanel.SetActive(true); --> Ahi metes el if
        Application.Quit();
        Debug.Log("Salir del juego");
        
        // Si es WEB
        Debug.Log("No se puede cerrar en WebGL. Por favor, cierra la pestaña manualmente.");
        // Redirigir a una URL externa (ej: tu web personal)
        // Application.OpenURL("https://ichi.io");

    }
}
