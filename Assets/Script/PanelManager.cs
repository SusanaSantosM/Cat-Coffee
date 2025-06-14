using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class PanelManager : MonoBehaviour
{
    [Header("OptionPanel")]
    public Slider volumeFx;
    public Slider volumeMusic;

    [Header("Panels")]
    public GameObject MainPanel;
    public GameObject OptionPanel;
    public GameObject HelpPanel;

    public AudioMixer mixer;
    public AudioSource fxsource;
    public AudioClip clickSound;


    private void Awake()
    {
        volumeFx.onValueChanged.AddListener(ChangeVolumeFx);
        volumeMusic.onValueChanged.AddListener(ChangeVolumeMaster);
    }


    // Controla los paneles que se verán según su selección
    public void OpenPanel(GameObject panel)
    {
        MainPanel.SetActive(false);
        OptionPanel.SetActive(false);
        HelpPanel.SetActive(false);

        // Guardar configuración si se está cerrando el panel de opciones
        if (!OptionPanel.activeSelf && panel != OptionPanel)
        {
            PlayerSettings settingsManager = Object.FindFirstObjectByType<PlayerSettings>();
            if (settingsManager != null)
            {
                settingsManager.SaveSettings();
            }
        }

        panel.SetActive(true);
        PlaySoundButton();

    }


    public void ChangeVolumeMaster(float v)
    {
        mixer.SetFloat("VolMaster", v);
    }

    public void ChangeVolumeFx(float v)
    {
        mixer.SetFloat("VolFx", v);
    }


    public void PlaySoundButton()
    {
        fxsource.PlayOneShot(clickSound);
    }

}
