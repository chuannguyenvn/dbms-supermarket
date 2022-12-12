using System;
using System.Collections.Generic;
using Mono.Data.Sqlite;
using System.Data;
using UnityEngine;

public class SQLQueryExecutor : PersistentSingleton<SQLQueryExecutor>
{
    private const string DATABASE_FILE_NAME = "database.db";
    private IDbConnection dbConnection;

    protected override void Awake()
    {
        base.Awake();

        string dir = Application.dataPath + "/StreamingAssets/" + DATABASE_FILE_NAME;
        string connection = "URI=file:" + dir;
        dbConnection = new SqliteConnection(connection);
        dbConnection.Open();
        
        ExecuteQuery("select * from interview");
    }

    public void ExecuteQuery(string query)
    {
        IDbCommand cmnd_read = dbConnection.CreateCommand();
        IDataReader reader;
        cmnd_read.CommandText = query;
        List<List<string>> result = new List<List<string>> {new List<string>()};

        try
        {
            reader = cmnd_read.ExecuteReader();
        }
        catch (SqliteException e)
        {
            Debug.Log(e.Message);
            return;
        }

        for (int i = 0; i < reader.FieldCount; i++)
        {
            result[0].Add(reader.GetName(i));
        }

        while (reader.Read())
        {
            string resultStr = "";
            for (int i = 0; i < reader.FieldCount; i++)
            {
                resultStr += reader[i].ToString();
            }

            Debug.Log(resultStr);
        }
    }
}