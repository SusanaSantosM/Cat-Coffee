using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void BotonStart()
    {   
        // Para ir a la escena del juego
        SceneManager.LoadScene(1);
    }

    public void BotonEnd()
    {
        // Si Android
        // Muestra un panel de confirmaci�n (ej: "�Seguro que quieres salir?")
        //ConfirmPanel.SetActive(true); --> Ahi metes el if
        Application.Quit();
        Debug.Log("Salir del juego");
        
        // Si es WEB
        Debug.Log("No se puede cerrar en WebGL. Por favor, cierra la pesta�a manualmente.");
        // Redirigir a una URL externa (ej: tu web personal)
    }

    public void BotonBack() 
    {
        // Vuelve a la escena del men�
        SceneManager.LoadScene(0);
    }

    public void BotonReset()
    {
        PlayerPrefs.DeleteAll(); // Borra configuraci�n de volumen u otras flags
        SaveSystem.DeleteSave(); // Borra datos binarios guardados como las coins

        Debug.Log("Datos de la demo reiniciados.");

        // Opcional: volver al men� o reiniciar la escena del juego
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Recarga la escena actual
    }
}
