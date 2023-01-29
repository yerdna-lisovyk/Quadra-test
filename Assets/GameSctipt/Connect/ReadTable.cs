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
    public List<Qustion> Questions { get; private set; }

    
    [SerializeField] private ConnectDB connect;

    private void Start()
    {
        ReadQuestion();
        ReadVariant();
        
    }

    private void ReadQuestion()
    {
        var query = string.Empty; 
        if (Questions == null) 
            Questions = new List<Qustion>(); 
        if (Questions.Count > 0) 
            Questions.Clear();

        try
        {
            MySqlCommand cmd = null;
            MySqlDataReader rdr = null;
            query = "SELECT * FROM questions WHERE Id_test = 3";
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
                            Questions.Add(question);
                        }
                    }
                    rdr.Dispose();
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
            foreach (var question in Questions)
            {
                query = "SELECT * FROM variants WHERE id_question = "+question.IDQuestion+"";
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
        catch (IOException ex) {Debug.Log(ex.ToString());}
    }
}
