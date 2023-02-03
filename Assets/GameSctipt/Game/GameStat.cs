using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStat : MonoBehaviour
{
    public int NumberCorrectQuestions { get; set; } //Колличество верных вопросов 
    public List<int> RightQuestions { get; set; } //id верных вопрсов
    public List<int> ErrorNumbers { get; set; } // id не правельных вариантов
    
    
}
