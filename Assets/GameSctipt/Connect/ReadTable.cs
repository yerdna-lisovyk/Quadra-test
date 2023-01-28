using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using MySql.Data.MySqlClient;
using UnityEngine;
using UnityEngine.Serialization;

public class ReadTable : MonoBehaviour
{
    private List<Qustion> _questions;
    [SerializeField] private ConnectDB connect;
    
    
    private void ReadQuestion()
    {
        var query = string.Empty; 
        if (_questions == null) 
            _questions = new List<Qustion>(); 
        if (_questions.Count > 0) 
            _questions.Clear();

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
                            _questions.Add(question);
                        }
                    }
                    rdr.Dispose();
                }
            }
        }
        catch (IOException ex) {Debug.Log(ex.ToString());}
    }
}
