using System;
using System.Collections.Generic;
using UnityEngine;


public class DatabaseManager : PersistentSingleton<DatabaseManager>
{
    private void Start()
    {
        // Code to connect to database.
    }

    private List<List<string>> ExecuteQuery(string query)
    {
        List<List<string>> queryResult = new();

        // Code to execute query and get the result.

        return queryResult;
    }

    /// <returns>ID, First_name, Last_name, Gender, Address, Phone_number, Date_of_birth, Type</returns>
    public List<string> GetCustomer(string ID)
    {
        // Delete this //
        return new List<string>()
        {
            "69420",
            "A",
            "Nguyen",
            "Male",
            "495/4/8 To Hien Thanh, D.10, HCM City",
            "0123696969",
            "1969/6/9",
            "Type?",
        };
        // Delete this //

        string query = "[SQL code here!]";
        return ExecuteQuery("query")[0];
    }
    
    /// <returns>Customer_ID, Issue_date, Saving_points</returns>
    public List<string> GetCustomerCard(string Customer_ID)
    {
        // Delete this //
        return new List<string>() {"6090609", "2022/6/9", "1696",};
        // Delete this //

        string query = "[SQL code here!]";
        return ExecuteQuery("query")[0];
    }
}