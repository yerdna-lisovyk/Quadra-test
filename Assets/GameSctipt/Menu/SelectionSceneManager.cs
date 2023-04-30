using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectionSceneManager : MonoBehaviour
{
    [SerializeField] private GameObject spawnPoint;
    [SerializeField] private GameObject prefab;
    [SerializeField] private InputField _inputFieldName;
    [SerializeField] private InputField _inputFieldBatch;

    public static List<GameObject> Objects = new List<GameObject>();
    private void Start()
    {
        GameStat.SelectionTest = 0;
        GameObject one = null;
        GameObject two = null;
        for (int i = 0; i < ReadTable.Tests.Count; i++)
        {
            if (i == 0)
            {
                one = Instantiate(prefab, spawnPoint.transform);
                one.GetComponentInChildren<Text>().text = ReadTable.Tests[i].TitleTest;
                one.GetComponentInChildren<TestSelection>().Test = ReadTable.Tests[i];
                
            }
            else
            {
                Vector3 transform = one.GetComponent<RectTransform>().position + new Vector3(0f, -0.7f, 0f);
                two = Instantiate(prefab, spawnPoint.transform);
                two.GetComponent<RectTransform>().position = transform;
                two.GetComponentInChildren<Text>().text = ReadTable.Tests[i].TitleTest;
                two.GetComponentInChildren<TestSelection>().Test = ReadTable.Tests[i];
                one = two;
            }
            Objects.Add(one);
        }
    }

    public void NextScene()
    {
        if (GameStat.SelectionTest !=0 && _inputFieldBatch.text!=""&& _inputFieldName.text!="")
        {
            GameStat.Batch = _inputFieldBatch.text;
            GameStat.FirstName = _inputFieldName.text;
            ReadTable.Questions = ReadTable.Tests[FindTest(GameStat.SelectionTest)].Qust;
            SceneManager.LoadScene("GameScene");
        }
     }

    private int FindTest(int id)
    {
        for (int i = 0; i < ReadTable.Tests.Count; i++)
        {
            if (id == ReadTable.Tests[i].IDTest)
            {
                return i;
            }
        }

        return 0;
    }
}
