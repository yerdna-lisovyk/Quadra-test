using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject panelSetting;
    public void NextScene()
    {
        SceneManager.LoadScene("SelectionScene");
    }
    public void Quit()
    {
        Application.Quit();
    }

    public void ShowHidePanelHowGame()
    {
        if (panel.activeSelf)
        {
            panel.SetActive(false);
            return;
        }
        panel.SetActive(true);
    }
    public void ShowHidePanelSetting()
    {
        if (panelSetting.activeSelf)
        {
            panelSetting.SetActive(false);
            return;
        }
        panelSetting.SetActive(true);
    }
}
