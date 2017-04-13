using UnityEngine;
using System;
using System.Data;
using Mono.Data.Sqlite;

public class HighScoreManager : MonoBehaviour
{
    private string connectionString;
    void Start ()
    {
        // conn = "URI=file:" + Application.dataPath + "/DB Browser로 만든 데이터베이스 이름.s3db";
        connectionString = "URI=file:" + Application.dataPath + "/Capsule.db";
        // DeleteScores(5000);
        // InsertScore(5000,"newnew");
        GetScores();
    }

    private void InsertScore(int newScore,String name) // playerid , new score 받으면 될거같다.
    {
        // IDbConnection
        using ( IDbConnection dbConnection = new SqliteConnection(connectionString) )
        {
            dbConnection.Open(); //Open connection to the database.

            // IDbCommand
            using ( IDbCommand dbCmd = dbConnection.CreateCommand() )
            {
                // sql문장 = "SELECT 조회할 컬럼 FROM 조회할 테이블";
                string sqlQuery = String.Format("Insert into Capsule(value,name) values (\"{0}\",\"{1}\") " , newScore, name);
                // dbcmd.Connection = dbconn; 위에서 쓰임
                dbCmd.CommandText = sqlQuery;
                // 쓰기
                dbCmd.ExecuteScalar();
                // 닫기
                dbConnection.Close();
                
            }
        }
    }

    private void GetScores ()
    {
        // IDbConnection
        using ( IDbConnection dbConnection = new SqliteConnection(connectionString))
        {
            dbConnection.Open(); //Open connection to the database.

            // IDbCommand
            using ( IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                // sql문장 = "SELECT 조회할 컬럼 FROM 조회할 테이블";
                string sqlQuery = "SELECT * " + "FROM Capsule";
                // dbcmd.Connection = dbconn; 위에서 쓰임
                dbCmd.CommandText = sqlQuery;
                
                // IDataReader
                using ( IDataReader reader = dbCmd.ExecuteReader())
                {
                    while ( reader.Read() )
                    {
                        // 변수타입은 컬럼 데이터 타입에 맞추면 된다.
                        int value = reader.GetInt32(0);
                        string name = reader.GetString(1);

                        Debug.Log("value= " + value + "  name =" + name);
                    }

                    dbConnection.Close();
                    reader.Close();
                }
            }
        }
    }

    private void DeleteScores (int id)
    {
        // IDbConnection
        using ( IDbConnection dbConnection = new SqliteConnection(connectionString) )
        {
            dbConnection.Open(); //Open connection to the database.

            // IDbCommand
            using ( IDbCommand dbCmd = dbConnection.CreateCommand() )
            {
                // sql문장 = "SELECT 조회할 컬럼 FROM 조회할 테이블";
                string sqlQuery = String.Format("Delete from Capsule where value =\"{0}\" " , id);
                
                // dbcmd.Connection = dbconn; 위에서 쓰임
                dbCmd.CommandText = sqlQuery;
                // 쓰기
                dbCmd.ExecuteScalar();
                // 닫기
                dbConnection.Close();

            }
        }
    }
}