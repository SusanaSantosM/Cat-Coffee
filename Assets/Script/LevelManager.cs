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

}
