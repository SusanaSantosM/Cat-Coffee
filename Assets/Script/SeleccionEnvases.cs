using UnityEngine;
using UnityEngine.EventSystems;
using static EnvaseEnMesa;

public class SeleccionEnvases : MonoBehaviour, IPointerDownHandler
{
    [System.Serializable]
    public class EnvaseSeleccionado
    {
        public Sprite sprite;
        public EnvaseEnMesa.TipoEnvase tipo;
    }

    public EnvaseSeleccionado envaseSel;
    public Transform envaseEnMesa; // Referencia al GameObject vacío en la mesa
    
    
    public void OnPointerDown(PointerEventData eventData)
    {
        SpriteRenderer renderer = envaseEnMesa.GetComponent<SpriteRenderer>();
        EnvaseEnMesa envaseScript = envaseEnMesa.GetComponent<EnvaseEnMesa>();

        if (renderer != null && envaseScript != null)
        {
            renderer.sprite = envaseSel.sprite;
            envaseScript.envase = envaseSel.tipo;

            // Animación
            //envaseEnMesa.transform.localScale = Vector3.one * 1.1f;
            //LeanTween.scale(envaseEnMesa.gameObject, Vector3.one, 0.3f).setEaseOutBack();
        }
        else 
        {
            Debug.LogError("Falta algun objecto o el sprite.");
        }
    }

}
