// 代码生成时间: 2025-09-02 14:38:05
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Threading.Tasks;

// DatabaseMigrationTool is a utility class designed to handle database migrations in Unity projects.
public class DatabaseMigrationTool
{
    private readonly string _connectionString;

    // Constructor for DatabaseMigrationTool.
    // Parameters:
    // connectionString: The connection string to the database.
    public DatabaseMigrationTool(string connectionString)
    {
        _connectionString = connectionString;
    }

    // Method to execute a migration script.
    // Parameters:
    // migrationScriptPath: The path to the SQL migration script file.
    public async Task MigrateDatabaseAsync(string migrationScriptPath)
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (SqlCommand command = new SqlCommand(File.ReadAllText(migrationScriptPath), connection))
                {
                    await command.ExecuteNonQueryAsync();
                }
            }
        }
        catch (SqlException ex)
        {
            // Handle SQL errors.
            Console.WriteLine($"SQL Error: {ex.Message}");
            throw;
        }
        catch (Exception ex)
        {
            // Handle other errors.
            Console.WriteLine($"Error: {ex.Message}");
            throw;
        }
    }

    // Method to check if the database is up to date with the latest migration script.
    // Returns:
    // True if the database is up to date, otherwise false.
    public bool IsDatabaseUpToDate(string latestMigrationScriptPath)
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(File.ReadAllText(latestMigrationScriptPath), connection))
                {
                    // Assuming the script checks for the existence of a migration table or similar.
                    return command.ExecuteScalar() != null;
                }
            }
        }
        catch (SqlException ex)
        {
            Console.WriteLine($"SQL Error: {ex.Message}");
            return false;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            return false;
        }
    }
}
