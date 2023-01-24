using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using MySql.Data;
using MySql.Data.MySqlClient; 

public class ConnectDB : MonoBehaviour
{
    // соединение 
    private MySqlConnection _con = null; 
    // команда к БД
    private MySqlCommand _cmd = null; 
    // чтение
    private MySqlDataReader _rdr = null; 
    // ошибки
    private MySqlError _er = null; 
    private string _constr = "Server=localhost;Database=controlltest;User ID=root;Password=;Pooling=true;CharSet=utf8;"; 
    void Awake() 
    { 
        try 
        { 
            // установка элемента соединения 
            _con = new MySqlConnection(_constr); 
 
            // посмотрим, сможем ли мы установить соединение 
            _con.Open(); 	
            Debug.Log("Connection State: " + _con.State); 
        } 
        catch (IOException ex)  {Debug.Log(ex.ToString());} 
        
    } 
}
