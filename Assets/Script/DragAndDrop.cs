using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DragAndDrop : MonoBehaviour
{
    private Vector3 startPosition;
    private Vector3 mousePosition;


    private void OnMouseDown()
    {   
        gameObject.GetComponent<Collider2D>().enabled = false;

        // Guarda la posición inicial
        startPosition = transform.position;
    }

    private void OnMouseDrag() 
    {
        // El objeto persiga al ratón en la posición de la escena y no la pantalla
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mousePosition.x, mousePosition.y, transform.position.z);

    }

    private void OnMouseUp()
    {
        gameObject.GetComponent<Collider2D>().enabled = true;


        // Dectecta las colisiones
        DetectColliders();

        // Detecta el limite de pantalla
        ScreenLimit();
    }

    private void DetectColliders() 
    {
        // Crear boxcastAll para detectar si hay un collider superpuesto a otro
        RaycastHit2D[] hit;

        hit = Physics2D.BoxCastAll(transform.position, transform.localScale, 0, transform.rotation.eulerAngles);


        // Detecta otro objeto con el tag "Objetos"
        for (int i = 0; i < hit.Length; i++)
        {
            Debug.Log("Impacta con " + hit[i].transform.gameObject.name);
            if (hit[i].transform.gameObject != this.gameObject && hit[i].transform.CompareTag("Objetos"))
            {
                transform.position = startPosition;
            }
        }
    }


    private void ScreenLimit() 
    {
        Vector3 screenSize = new Vector3(Screen.width, Screen.height, 0);
        screenSize = Camera.main.ScreenToWorldPoint(screenSize);

        Vector3 transPos = transform.position;

        // Posición x
        if (transPos.x > screenSize.x)
        {
            transform.position = startPosition;
        }

        if (transPos.x < -screenSize.x)
        {
            transform.position = startPosition;
        }


        // Posición y
        if (transPos.y > screenSize.y)
        {
            transform.position = startPosition;
        }

        if (transPos.y < -screenSize.y)
        {
            transform.position = startPosition;
        }
    }
}
