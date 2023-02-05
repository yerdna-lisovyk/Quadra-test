using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
   
   
   private int _nextQuestionNumber = 0;

   private static GameManager _instans;
   [SerializeField] private List<Button> buttons;
   [SerializeField] private Text textQuestion;
   [SerializeField] private Image image;
   private void Start()
   {
      _instans = this;
      NextQuestion();
   }

   public static void StaticNextQuestion()
   {
      _instans.NextQuestion();
   }
   
   private void NextQuestion()
   {
      textQuestion.text = ReadTable.Questions[_nextQuestionNumber].Description;
      if (ReadTable.Questions[_nextQuestionNumber].Img != null)
      {
         var tmp = ReadTable.Questions[_nextQuestionNumber].Img;
         image.color = new Color(1, 1, 1, 1);
         var mySprite = Sprite.Create(tmp, new Rect(0.0f, 0.0f, tmp.width, tmp.height), new Vector2(0.5f, 0.5f), 100.0f);
         image.sprite = mySprite;
      }
      else
      {
         image.color = new Color(1, 1, 1, 0);
      }
      var k = 0;
      foreach (var button in buttons)
      {
         button.GetComponent<InfoVariant>().Variant = ReadTable.Questions[_nextQuestionNumber].Variants[k];
         button.GetComponentInChildren<Text>().text = ReadTable.Questions[_nextQuestionNumber].Variants[k].Description;
         k++;
      }
      
      _nextQuestionNumber++;
   }
}
