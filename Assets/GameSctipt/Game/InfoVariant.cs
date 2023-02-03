using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class InfoVariant : MonoBehaviour
{
    public Variant Variant { private get; set; }
    [SerializeField] private GameStat gameStat;

   
    public void GetInfo()
    {
        if (Variant.Loyalty == true)
        {
            gameStat.NumberCorrectQuestions++;
            gameStat.RightQuestions.Add(Variant.IDQuestion);
        }
        else
        {
            gameStat.ErrorNumbers.Add(Variant.IDVariant);
        }
        GameManager.StaticNextQuestion();
    }
}
