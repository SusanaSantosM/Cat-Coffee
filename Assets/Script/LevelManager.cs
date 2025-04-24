using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour 
{
    // Métodos para ir a cada escena
    public void BotonStart() 
    {
        SceneManager.LoadScene(1);
    }

    public void BotonOption()
    {
    }

    public void BotonEnd() 
    {
        Debug.Log("Salir del juego");
        Application.Quit();
    }

    //public void BotonStore(){}
    
}
