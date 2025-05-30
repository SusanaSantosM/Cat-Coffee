using UnityEngine;

public class GestorPuntuacion
{
    public float dineroActual = 0f;
    public int puntosActuales = 0;

    public float dineroParaPunto = 5f;
    public int puntosPorAcumulacion = 5;


    public void AnadirGanancia(float cantidad) 
    {
        dineroActual += cantidad;
        Debug.Log($"Dinero actual:  {dineroActual}€");

        while (dineroActual >= dineroParaPunto) 
        {
            puntosActuales += puntosPorAcumulacion;
            dineroActual -= dineroParaPunto;
            Debug.Log($"Ganaste {puntosPorAcumulacion} puntos! Puntos totales: {puntosActuales}");
        }
    }

    public void RestablecerPuntuacion()
    { 
        dineroActual = 0f;
        puntosActuales = 0;
        Debug.Log("Puntuación y dinero restablecidos");
    }

    public GestorPuntuacion() 
    {
        Debug.Log("GestorPuntuacion iniciando...");
    }
}
