using System.Collections.Generic;
using Mono.Data.Sqlite;
using System.Data;
using System.Linq;
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
}