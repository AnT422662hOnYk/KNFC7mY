// 代码生成时间: 2025-08-16 09:26:28
using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A simple audit log system for Unity application.
/// </summary>
public class AuditLogSystem
{
    private static readonly string LogFileName = "audit_log.txt";
    private static readonly string LogFilePath = Application.persistentDataPath + "/" + LogFileName;
    private static Dictionary<string, List<string>> auditLogEntries = new Dictionary<string, List<string>>();

    /// <summary>
    /// Logs an event with associated data.
    /// </summary>
    /// <param name="action">The action that occurred.</param>
    /// <param name="data">Any data associated with the action.</param>
    public static void LogEvent(string action, Dictionary<string, string> data)
    {
        try
        {
            string dateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string logEntry = $"[{dateTime}] Action: {action}, Data: {data}";

            // Ensure the action is in the dictionary.
            if (!auditLogEntries.ContainsKey(action))
                auditLogEntries[action] = new List<string>();

            auditLogEntries[action].Add(logEntry);
            SaveLogToFile();
        }
        catch (Exception ex)
        {
            Debug.LogError("Error logging audit event: " + ex.Message);
        }
    }

    /// <summary>
    /// Saves the audit log entries to a file.
    /// </summary>
    private static void SaveLogToFile()
    {
        try
        {
            string fileContent = string.Join("
", auditLogEntries.Values.SelectMany(l => l));
            System.IO.File.WriteAllText(LogFilePath, fileContent);
        }
        catch (Exception ex)
        {
            Debug.LogError("Error saving audit log to file: " + ex.Message);
        }
    }

    /// <summary>
    /// Clears all audit log entries.
    /// </summary>
    public static void ClearLog()
    {
        auditLogEntries.Clear();
        SaveLogToFile();
    }
}
