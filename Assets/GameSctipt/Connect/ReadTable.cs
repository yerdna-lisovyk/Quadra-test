using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using MySql.Data.MySqlClient;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;


public class ReadTable : MonoBehaviour
{
    public static List<Qustion> Questions { get; set; }
    public static List<Test> Tests { get; set; }
    
    
    [SerializeField] private ConnectDB connect;

    private void Awake()
    {
        ReadTest();
        ReadQuestion();
        ReadVariant();
        
    }

    private void ReadTest()
    {
        var query = string.Empty; 
        if (Tests == null) 
            Tests = new List<Test>(); 
        if (Tests.Count > 0) 
            Tests.Clear();
        try
        {
            MySqlCommand cmd = null;
            MySqlDataReader rdr = null;
            query = "SELECT * FROM test";
            connect.TryConnect();
            using (connect.Con)
            {
                using (cmd = new MySqlCommand(query, connect.Con))
                {
                    rdr = cmd.ExecuteReader();
                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            var test = new Test();
                            test.IDTest = int.Parse(rdr["id_test"].ToString());
                            test.TitleTest = rdr["title_test"].ToString();
                            Tests.Add(test);
                        }
                    }
                    rdr.Dispose();
                }
            }
        }
        catch (IOException ex) {Debug.Log(ex.ToString());}
    }

    private void ReadQuestion()
    {
        var query = string.Empty;
        try
        {
            MySqlCommand cmd = null;
            MySqlDataReader rdr = null;
            foreach (var test in Tests)
            {
                if (test.Qust == null) 
                    test.Qust= new List<Qustion>();
                query = "SELECT * FROM questions WHERE Id_test  = "+test.IDTest+"";
                connect.TryConnect();
                using (connect.Con)
                {
                    using (cmd = new MySqlCommand(query, connect.Con))
                    {
                        rdr = cmd.ExecuteReader();
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                var question = new Qustion();
                                question.IDQuestion = int.Parse(rdr["Id_question"].ToString());
                                question.Description = rdr["description"].ToString();
                                if (rdr["img"].ToString() != "")
                                {
                                    byte[] img = (byte[])rdr["img"];
                                    question.Img = new Texture2D(512, 512);
                                    question.Img.LoadImage(img, true);
                                }
                                test.Qust.Add(question);
                            }
                        }

                        rdr.Dispose();
                    }
                }
            }
        }
        catch (IOException ex) {Debug.Log(ex.ToString());}
    }
    private void ReadVariant()
    {
        var query = string.Empty;
        try
        {
            MySqlCommand cmd = null;
            MySqlDataReader rdr = null;
            foreach (var test in Tests)
            {

                foreach (var question in test.Qust)
                {
                    question.Variants = new List<Variant>();
                    query = "SELECT * FROM variants WHERE id_question = " + question.IDQuestion + "";
                    connect.TryConnect();
                    using (connect.Con)
                    {
                        using (cmd = new MySqlCommand(query, connect.Con))
                        {
                            rdr = cmd.ExecuteReader();
                            if (rdr.HasRows)
                            {
                                while (rdr.Read())
                                {
                                    var variant = new Variant();
                                    variant.IDVariant = int.Parse(rdr["id_variants"].ToString());
                                    variant.IDQuestion = int.Parse(rdr["id_question"].ToString());
                                    variant.Description = rdr["description"].ToString();
                                    variant.Loyalty = bool.Parse(rdr["loyalty"].ToString());
                                    question.Variants.Add(variant);
                                }
                            }

                            rdr.Dispose();
                        }
                    }
                }
            }

        }
        catch (IOException ex) {Debug.Log(ex.ToString());}
    }
}
