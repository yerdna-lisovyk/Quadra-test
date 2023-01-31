using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
   private int _nextQuestionNumber = 0;
   private int _trueQuestion = 0;
   
   [SerializeField] private List<Button> buttons;
   [SerializeField] private Text textQuestion;
   [SerializeField] private Image image;
   [SerializeField] private ReadTable table;
   private void Start()
   {
      NextQuestion();
      NextQuestion();
   }

   private void NextQuestion()
   {
      textQuestion.text = table.Questions[_nextQuestionNumber].Description;
      if (table.Questions[_nextQuestionNumber].Img != null)
      {
         var tmp = table.Questions[_nextQuestionNumber].Img;
         var mySprite = Sprite.Create(tmp, new Rect(0.0f, 0.0f, tmp.width, tmp.height), new Vector2(0.5f, 0.5f), 100.0f);
         image.sprite = mySprite;
      }
      var k = 0;
      foreach (var button in buttons)
      {
         button.GetComponentInChildren<Text>().text = table.Questions[_nextQuestionNumber].Variants[k].Description;
         k++;
      }

      _nextQuestionNumber++;
   }
}
