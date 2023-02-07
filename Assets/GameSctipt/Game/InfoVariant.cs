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
            ReadTable.Questions[GameManager.NextQuestionNumber - 1].Accuracy = true;
        }
        else
        {
            ReadTable.Questions[GameManager.NextQuestionNumber - 1].Accuracy = false;
        }
        GameManager.StaticNextQuestion();
    }
}
