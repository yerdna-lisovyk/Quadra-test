using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class InfoVariant : MonoBehaviour
{
    public Variant Variant { private get; set; }
    

    public void GetInfo()
    {
        if (Variant.Loyalty == true)
        {
            GameStat.NumberCorrectQuestions++;
            GameStat.RightQuestions.Add(Variant.IDQuestion);
        }
        else
        {
            GameStat.ErrorNumbers.Add(Variant.IDVariant);
        }
        GameManager.StaticNextQuestion();
    }
}
