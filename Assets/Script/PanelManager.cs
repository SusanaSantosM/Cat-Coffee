using UnityEngine;
using UnityEngine.UI;

public class PanelManager : MonoBehaviour
{
    [Header("OptionPanel")]
    public Slider volumenFx;
    public Slider volumeMusic;

    [Header("Panels")]
    public GameObject MainPanel;
    public GameObject OptionPanel;
    public GameObject HelpPanel;

    // Controla los paneles que se verán según su selección
    public void OpenPanel(GameObject panel) 
    { 
        MainPanel.SetActive(false);
        OptionPanel.SetActive(false);
        HelpPanel.SetActive(false);

        panel.SetActive(true);
        
    }

}
