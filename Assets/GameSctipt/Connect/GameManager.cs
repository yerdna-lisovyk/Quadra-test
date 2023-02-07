using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
   
   
   public static int NextQuestionNumber { get; private set; }

   private static GameManager _instans;
   [SerializeField] private List<Button> buttons;
   [SerializeField] private Text textQuestion;
   [SerializeField] private Image image;
   private void Start()
   {
      _instans = this;
      NextQuestionNumber = 0;
      NextQuestion();
   }

   public static void StaticNextQuestion()
   {
      _instans.NextQuestion();
   }
   
   private void NextQuestion()
   {
      if (ReadTable.Questions.Count == NextQuestionNumber)
      {
         SceneManager.LoadScene("EndScene");
         return;
      }
      textQuestion.text = ReadTable.Questions[NextQuestionNumber].Description;
      if (ReadTable.Questions[NextQuestionNumber].Img != null)
      {
         var tmp = ReadTable.Questions[NextQuestionNumber].Img;
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
         button.GetComponent<InfoVariant>().Variant = ReadTable.Questions[NextQuestionNumber].Variants[k];
         button.GetComponentInChildren<Text>().text = ReadTable.Questions[NextQuestionNumber].Variants[k].Description;
         k++;
      }
      
      NextQuestionNumber++;
   }
}
