// 代码生成时间: 2025-09-02 07:31:33
 * Notes:
 * - Structured for clarity and easy understanding.
 * - Implements proper error handling.
 * - Includes necessary comments and documentation.
 * - Adheres to C# best practices.
 * - Ensures maintainability and extensibility of the code.
 */

using System;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

/// <summary>
/// A class responsible for collecting and managing error logs.
/// </summary>
public class ErrorLogCollector
{
    private const string LogDirectory = "Logs";
    private const string LogFileName = "error_log.txt";
    private const string LogFilePath = LogDirectory + "/" + LogFileName;

    /// <summary>
    /// Initializes the error log collector by checking if the log directory exists,
    /// and creates it if it does not.
    /// </summary>
    public void Initialize()
    {
        if (!Directory.Exists(LogDirectory))
        {
            Directory.CreateDirectory(LogDirectory);
        }
    }

    /// <summary>
    /// Records a new error log to the file system.
    /// </summary>
    /// <param name="errorMessage">The error message to log.</param>
    public void RecordError(string errorMessage)
    {
        try
        {
            File.AppendAllText(LogFilePath, errorMessage + Environment.NewLine);
        }
        catch (Exception ex)
        {
            Debug.LogError("Failed to record error: " + ex.Message);
        }
    }

    /// <summary>
    /// Retrieves a list of error logs from the file system.
    /// </summary>
    /// <returns>A list of error logs.</returns>
    public List<string> RetrieveErrorLogs()
    {
        try
        {
            if (File.Exists(LogFilePath))
            {
                return new List<string>(File.ReadAllLines(LogFilePath));
            }
        }
        catch (Exception ex)
        {
            Debug.LogError("Failed to retrieve error logs: " + ex.Message);
        }
        return new List<string>();
    }

    /// <summary>
    /// Clears all error logs from the file system.
    /// </summary>
    public void ClearErrorLogs()
    {
        try
        {
            if (File.Exists(LogFilePath))
            {
                File.Delete(LogFilePath);
            }
        }
        catch (Exception ex)
        {
            Debug.LogError("Failed to clear error logs: " + ex.Message);
        }
    }
}
