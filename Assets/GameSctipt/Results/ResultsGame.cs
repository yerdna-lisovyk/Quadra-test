using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ResultsGame: MonoBehaviour
{
    [SerializeField] private Text title;
    [SerializeField] private Text pointsTotalsText;
    [SerializeField] private GameObject prefab;
    [SerializeField] private GameObject spawnPoint;
    
    private void Start()
    {
        GameObject one = null;
        GameObject two = null;
        for (int i = 0; i < ReadTable.Questions.Count; i++)
        {
            if (i == 0)
            {
                one = Instantiate(prefab, spawnPoint.transform);
                one.GetComponent<Text>().text = ReadTable.Questions[0].Description;
            }
            else
            {
                Vector3 transform = one.GetComponent<RectTransform>().position + new Vector3(0f, -0.65f, 0f);
                two = Instantiate(prefab, spawnPoint.transform);
                two.GetComponent<RectTransform>().position = transform;
                two.GetComponent<Text>().text = ReadTable.Questions[i].Description;
                one = two;
            }
            if (ReadTable.Questions[i].Accuracy == true)
            {
                one.GetComponent<Text>().color= Color.green;
            }
            else
            {
                one.GetComponent<Text>().color= Color.red;
            }
        }
        double x = ReadTable.Questions.Count;
         double y = GameStat.NumberCorrectQuestions;
         if (((double) y / x)* 100>60)
         {
             title.text = "Молодец";
         }
         else
         {
             title.text = "Псторайся";
         }
 
         pointsTotalsText.text = y.ToString() + " /" + x.ToString();
    }
    
    
   
}
