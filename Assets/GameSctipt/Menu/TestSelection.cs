using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestSelection : MonoBehaviour
{
    public Test Test { get; set; }
    [SerializeField] private Sprite _close;
    [SerializeField] private Sprite _apply;

    private void Start()
    {
        GetComponent<Image>().color = Color.red;
    }

    public void Select()
    {
        TorgeOff();
        GameStat.SelectionTest = Test.IDTest;
        GetComponent<Image>().sprite = _apply;
        GetComponent<Image>().color = Color.green;
        
    }

    private void TorgeOff()
    {
        foreach (var gameObject in SelectionSceneManager.Objects)
        {
            gameObject.GetComponentInChildren<Image>().sprite = _close;
            gameObject.GetComponentInChildren<Image>().color = Color.red;
        }
    }
}
