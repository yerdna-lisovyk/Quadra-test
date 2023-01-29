using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using UnityEngine;
using MySql.Data;
using MySql.Data.MySqlClient; 

public class ConnectDB : MonoBehaviour
{

    public MySqlConnection Con { get; private set; }
    private string _constr = "Server=localhost;Database=controlltest;User ID=root;Password=;Pooling=true;CharSet=utf8;"; 
    private void Awake() 
    {
        TryConnect();
    }
    

    public void TryConnect()
    {
        try 
        {
            Con = new MySqlConnection(_constr);
            if (Con.State != ConnectionState.Open)
            {
                Con.Open();
            }
        } 
        catch (IOException ex)  {Debug.Log(ex.ToString());} 
    }

    private void OnApplicationQuit()
    {
        if (Con != null)
        {
            if (Con.State != ConnectionState.Closed)
                Con.Close();
            Con.Dispose();

        }
    }
}
