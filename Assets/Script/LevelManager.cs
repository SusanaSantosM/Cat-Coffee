using UnityEngine;
using UnityEngine.SceneManagement;

public class LvelManager : MonoBehaviour
{
    // Métodos para ir a cada escena
    public void BotonStart()
    {
        SceneManager.LoadScene(1);
    }

    /*public void BotonOption()
    {
        Debug.Log("Boton Opciones");
    }

    public void BotonHelp()
    {
        Debug.Log("Boton Ayuda");
    }*/

    public void BotonEnd()
    {
        Debug.Log("Salir del juego");
        Application.Quit();
    }
}
