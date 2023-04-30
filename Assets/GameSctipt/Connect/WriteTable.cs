using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using MySql.Data.MySqlClient;

public class WriteTable : MonoBehaviour
{
    [SerializeField] private ConnectDB connect;
    public static List<Leaderboard> LeaderboardTable { get; set; }
    public  void WriteLeaderboard()
    {
        var query = string.Empty; 
        MySqlCommand cmd = null;
        try
        {
            query = "INSERT INTO leaderboard (Id_test,fio,score,batch) VALUES (?id,?fio,?score,?batch)";
            connect.TryConnect();
            using (connect.Con)
            {
                using (cmd = new MySqlCommand(query, connect.Con))
                {
                    MySqlParameter oParam = cmd.Parameters.Add("?id", MySqlDbType.VarChar); 
                    oParam.Value = GameStat.SelectionTest; 
                    MySqlParameter oParam1 = cmd.Parameters.Add("?fio", MySqlDbType.VarChar); 
                    oParam1.Value = GameStat.FirstName;
                    MySqlParameter oParam2 = cmd.Parameters.Add("?score", MySqlDbType.Int32); 
                    oParam2.Value = GameStat.NumberCorrectQuestions*3;
                    MySqlParameter oParam3 = cmd.Parameters.Add("?batch", MySqlDbType.VarChar); 
                    oParam3.Value = GameStat.Batch;
                    cmd.ExecuteNonQuery(); 
                }
            }
        }
        catch (IOException ex) {Debug.Log(ex.ToString());}

        ReadLeaderboard();
    }
    private void ReadLeaderboard()
    {
        var query = string.Empty; 
        if (LeaderboardTable == null) 
            LeaderboardTable = new List<Leaderboard>(); 
        if (LeaderboardTable.Count > 0) 
            LeaderboardTable.Clear();
        try
        {
            MySqlCommand cmd = null;
            MySqlDataReader rdr = null;
            query = "SELECT * FROM leaderboard where Id_test = "+ GameStat.SelectionTest+" ORDER BY score DESC LIMIT 10";
            connect.TryConnect();
            using (connect.Con)
            {
                using (cmd = new MySqlCommand(query, connect.Con))
                {
                    rdr = cmd.ExecuteReader();
                    if (rdr.HasRows)
                    {
                        int n=1;
                        while (rdr.Read())
                        {
                            var leaderboard = new Leaderboard();
                            leaderboard.Name = rdr["fio"].ToString();
                            leaderboard.Score = int.Parse(rdr["score"].ToString());
                            leaderboard.Batch = rdr["batch"].ToString();
                            leaderboard.Place =n;
                            LeaderboardTable.Add(leaderboard);
                            n++;
                        }
                    }
                    rdr.Dispose();
                }
            }
        }
        catch (IOException ex) {Debug.Log(ex.ToString());}
    }
    
    
}
