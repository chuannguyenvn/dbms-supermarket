using System;
using System.Collections.Generic;
using Mono.Data.Sqlite;
using System.Data;
using System.Linq;
using System.Text;
using Dapper;
using UnityEngine;


public class DapperFacade : PersistentSingleton<DapperFacade>
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
    }

    public List<T> Query<T>(string query, object param = null)
    {
        return dbConnection.Query<T>(query, param).ToList();
    }

    public void Execute(string query, object param = null)
    {
        dbConnection.Execute(query, param);
    }

    public string FreeQuery(string query)
    {
        IDbCommand cmnd_read = dbConnection.CreateCommand();
        IDataReader reader;
        cmnd_read.CommandText = query;
        StringBuilder result = new StringBuilder();
        try
        {
            reader = cmnd_read.ExecuteReader();
        }
        catch (SqliteException e)
        {
            result.Append(string.Join(" ",
                e.Message.Split(new[] {'\r'}, StringSplitOptions.RemoveEmptyEntries)));
            return result.ToString();
        }


        result.Append(" | ");
        for (int i = 0; i < reader.FieldCount; i++)
        {
            result.Append(reader.GetName(i) + " | ");
        }

        while (reader.Read())
        {
            result.Append("\n | ");
            for (int i = 0; i < reader.FieldCount; i++)
            {
                result.Append(reader[i] + " | ");
            }
        }

        return result.ToString();
    }
}