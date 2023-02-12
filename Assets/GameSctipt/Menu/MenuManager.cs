using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void NextScene()
    {
        SceneManager.LoadScene("SelectionScene");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
