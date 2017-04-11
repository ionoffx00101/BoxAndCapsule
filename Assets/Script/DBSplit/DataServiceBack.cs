using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Data;
using Mono.Data.Sqlite;

public class DataServiceBack : MonoBehaviour {

    //public IDbConnection getDBconn (String DatabaseName)
    //   {
    //       //var dbPath = string.Format(@"Assets/StreamingAssets/{0}" , DatabaseName);
    //       string conn = "URI=file:" + Application.dataPath + "/"+DatabaseName+".db";

    //       IDbConnection dbconn;
    //       dbconn = (IDbConnection) new SqliteConnection(conn);

    //       return dbconn;
    //   }

    private String DatabaseName = "Capsule";

    public IDbConnection getDBconn()
    {
        //var dbPath = string.Format(@"Assets/StreamingAssets/{0}" , DatabaseName);
        string conn = "URI=file:" + Application.dataPath + "/" + DatabaseName + ".db";

        IDbConnection dbconn;
        dbconn = (IDbConnection) new SqliteConnection(conn);

        return dbconn;
    }

}
