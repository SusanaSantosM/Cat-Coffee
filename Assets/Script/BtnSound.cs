using UnityEngine;
using UnityEngine.UI;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public AudioClip clickSound;    //Se asigna el sonido desde el inspector
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponentInParent<AudioSource>();
        //audioSource = GetComponentInParent<Canvas>().GetComponent<AudioSource>();


        //Configura el botón para reproducir sonido al hacer clic
        Button btn = GetComponentInParent<Button>();
        btn.onClick.AddListener(PlayClickSound);
    }

    void PlayClickSound()
    {
        if (clickSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(clickSound);
        }
    }
}
