// 代码生成时间: 2025-09-15 22:09:15
using System;
using System.IO;
using System.Text.Json;
using UnityEngine;

/// <summary>
/// Handles data backup and restoration functionality.
/// </summary>
public class DataBackupRestore
{
    private const string DataFilePath = "data.json"; // Location of the data file.
    private const string BackupFolderPath = "backups"; // Location of the backup folder.

    /// <summary>
    /// Backs up the current data to a new file in the backup folder.
    /// </summary>
    /// <param name="data">The data to back up.</param>
    public void BackupData<T>(T data)
    {
        try
        {
            // Serialize the data object to JSON.
            string jsonData = JsonSerializer.Serialize(data);

            // Create the backup folder if it does not exist.
            if (!Directory.Exists(BackupFolderPath))
            {
                Directory.CreateDirectory(BackupFolderPath);
            }

            // Save the backup with a unique timestamped filename.
            string backupFileName = $"backup_{DateTime.Now:yyyyMMddHHmmss}.json";
            File.WriteAllText(Path.Combine(BackupFolderPath, backupFileName), jsonData);

            Debug.Log($"Data backup saved to {backupFileName}");
        }
        catch (Exception ex)
        {
            Debug.LogError($"Backup failed: {ex.Message}");
        }
    }

    /// <summary>
    /// Restores data from the latest backup file.
    /// </summary>
    /// <typeparam name="T">The type of the data to restore.</typeparam>
    /// <returns>The restored data object.</returns>
    public T RestoreData<T>()
    {
        try
        {
            // Get the latest backup file.
            DirectoryInfo backupDirInfo = new DirectoryInfo(BackupFolderPath);
            var latestBackupFile = backupDirInfo.EnumerateFiles()
                .OrderByDescending(f => f.LastWriteTime)
                .FirstOrDefault();

            if (latestBackupFile == null)
            {
                Debug.LogError("There are no backups to restore.");
                return default;
            }

            // Read and deserialize the backup file's content.
            string jsonData = File.ReadAllText(latestBackupFile.FullName);
            T restoredData = JsonSerializer.Deserialize<T>(jsonData);

            Debug.Log($"Data restored from {latestBackupFile.Name}");
            return restoredData;
        }
        catch (Exception ex)
        {
            Debug.LogError($"Restore failed: {ex.Message}");
            return default;
        }
    }
}
