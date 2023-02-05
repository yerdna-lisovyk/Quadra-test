using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameStat 
{
    public static int NumberCorrectQuestions { get; set; } //Колличество верных вопросов 
    public static List<int> RightQuestions { get; set; } //id верных вопрсов
    public static List<int> ErrorNumbers { get; set; } // id не правельных вариантов
    
    static GameStat()
    {
        ErrorNumbers = new List<int>();
        RightQuestions = new List<int>();
    }
}
