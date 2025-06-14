using UnityEngine;
using UnityEngine.UI;

public class PlayerSettings : MonoBehaviour
{
    public Slider volumeFxSlider;
    public Slider volumeMusicSlider;

    private const string VolumeFxKey = "VolumeFx";
    private const string VolumeMusicKey = "VolumeMusic";

    void Start()
    {
        LoadSettings();
    }

    public void SaveSettings()
    {
        PlayerPrefs.SetFloat(VolumeFxKey, volumeFxSlider.value);
        PlayerPrefs.SetFloat(VolumeMusicKey, volumeMusicSlider.value);
        PlayerPrefs.Save(); // Asegura que se escriba inmediatamente

        Debug.Log("Configuraci�n de audio guardada.");
    }

    public void LoadSettings()
    {
        // Si existen preferencias previas, las cargamos. Si no, dejamos el valor por defecto del slider
        if (PlayerPrefs.HasKey(VolumeFxKey))
            volumeFxSlider.value = PlayerPrefs.GetFloat(VolumeFxKey);

        if (PlayerPrefs.HasKey(VolumeMusicKey))
            volumeMusicSlider.value = PlayerPrefs.GetFloat(VolumeMusicKey);

        Debug.Log("Configuraci�n de audio cargada.");
    }
}
