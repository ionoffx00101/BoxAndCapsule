using UnityEngine;
using System;
using System.Data;
using Mono.Data.Sqlite;

public class DBAccess : MonoBehaviour
{
    void Start ()
    {
        // conn = "URI=file:" + Application.dataPath + "/DB Browser로 만든 데이터베이스 이름.s3db";
        string conn = "URI=file:" + Application.dataPath + "/Capsule.db";

        // IDbConnection
        IDbConnection dbconn;
        dbconn = (IDbConnection) new SqliteConnection(conn);
        dbconn.Open(); //Open connection to the database.

        // IDbCommand
        IDbCommand dbcmd = dbconn.CreateCommand();
        // sql문장 = "SELECT 조회할 컬럼 FROM 조회할 테이블";
        string sqlQuery = "SELECT value,name " + "FROM Capsule";
        // dbcmd.Connection = dbconn; 위에서 쓰임
        dbcmd.CommandText = sqlQuery;

        // IDataReader
        IDataReader reader = dbcmd.ExecuteReader();
        while ( reader.Read() )
        {
            // 변수타입은 컬럼 데이터 타입에 맞추면 된다.
            int value = reader.GetInt32(0);
            string name = reader.GetString(1);

            Debug.Log("value= " + value + "  name =" + name);
        }

        // 닫아주고 초기화 시켜주는 곳
        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;
    }
}