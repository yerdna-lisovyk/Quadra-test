using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using MySql.Data.MySqlClient;
using UnityEngine;
using UnityEngine.Serialization;

public class ReadTable : MonoBehaviour
{
    public List<Qustion> Questions { get; private set; }
    public List<Variant> Variants { get; private set; }
    
    [SerializeField] private ConnectDB connect;
    
    
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
            query = "SELECT * FROM questions WHERE Id_test = 1";
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
        if (Variants == null) 
            Variants = new List<Variant>(); 
        if (Variants.Count > 0) 
            Variants.Clear();

        try
        {
            MySqlCommand cmd = null;
            MySqlDataReader rdr = null;
            query = "SELECT * FROM questions WHERE Id_test = 1";
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
                            var question = new Variant();
                            question.IDQuestion = int.Parse(rdr["Id_question"].ToString());
                            question.Description = rdr["description"].ToString();
                            question.Loyalty = bool.Parse(rdr["loyalty"].ToString());
                            Variants.Add(question);
                        }
                    }
                    rdr.Dispose();
                }
            }
        }
        catch (IOException ex) {Debug.Log(ex.ToString());}
    }
}
