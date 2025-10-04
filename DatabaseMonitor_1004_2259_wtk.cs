// 代码生成时间: 2025-10-04 22:59:45
using System;
using System.Data;
using UnityEngine;
using System.Data.SqlClient; // 用于数据库连接

/// <summary>
/// DatabaseMonitor class to monitor database status and execute basic operations.
/// </summary>
public class DatabaseMonitor
{
    private string connectionString; // Database connection string

    /// <summary>
    /// Constructor to initialize the database connection string.
    /// </summary>
    /// <param name="connectionString">The connection string for the database.</param>
    public DatabaseMonitor(string connectionString)
    {
        this.connectionString = connectionString;
    }

    /// <summary>
    /// Method to check if the database connection is alive and responsive.
    /// </summary>
    /// <returns>True if the database is responding, otherwise false.</returns>
    public bool IsDatabaseResponsive()
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                // If no exception is thrown, the database is responsive.
                return true;
            }
        }
        catch (SqlException ex)
        {
            Debug.LogError("Database connection error: " + ex.Message);
            return false;
        }
    }

    /// <summary>
    /// Method to execute a SQL command on the database.
    /// </summary>
    /// <param name="commandText">The SQL command to be executed.</param>
    /// <returns>True if the command executed successfully, otherwise false.</returns>
    public bool ExecuteSqlCommand(string commandText)
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(commandText, connection))
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    return true;
                }
            }
        }
        catch (SqlException ex)
        {
            Debug.LogError("SQL execution error: " + ex.Message);
            return false;
        }
    }

    /// <summary>
    /// Method to retrieve data from the database.
    /// </summary>
    /// <param name="query">The SQL query to be executed.</param>
    /// <returns>A DataTable containing the query results.</returns>
    public DataTable RetrieveData(string query)
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        return dataTable;
                    }
                }
            }
        }
        catch (SqlException ex)
        {
            Debug.LogError("Data retrieval error: " + ex.Message);
            return null;
        }
    }
}
