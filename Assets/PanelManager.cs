using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelManager : MonoBehaviour
{
    [SerializeField] GameObject pausePanel;
    [SerializeField] GameObject optionsPanel;

    public void DisplayPausePanel(){

        optionsPanel.SetActive(false);
        pausePanel.SetActive(true);
    }

    public void DisplayOptionsPanel(){

        pausePanel.SetActive(false);     
        optionsPanel.SetActive(true);
    }
}
