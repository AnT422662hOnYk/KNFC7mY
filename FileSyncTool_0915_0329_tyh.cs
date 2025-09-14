// 代码生成时间: 2025-09-15 03:29:07
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// A utility tool for file backup and synchronization.
/// </summary>
public class FileSyncTool
{
    private string sourcePath;
    private string destinationPath;

    /// <summary>
    /// Initializes a new instance of the FileSyncTool class.
    /// </summary>
    /// <param name="sourcePath">The path of the source directory.</param>
    /// <param name="destinationPath">The path of the destination directory.</param>
    public FileSyncTool(string sourcePath, string destinationPath)
    {
        this.sourcePath = sourcePath;
        this.destinationPath = destinationPath;
    }

    /// <summary>
    /// Synchronizes files from the source directory to the destination directory.
    /// </summary>
    public void SyncFiles()
    {
        try
        {
            if (!Directory.Exists(sourcePath))
            {
                Debug.LogError("Source directory does not exist: " + sourcePath);
                return;
            }

            if (!Directory.Exists(destinationPath))
            {
                Directory.CreateDirectory(destinationPath);
            }

            IEnumerable<string> sourceFiles = Directory.GetFiles(sourcePath);
            foreach (var file in sourceFiles)
            {
                string fileName = Path.GetFileName(file);
                string destinationFile = Path.Combine(destinationPath, fileName);

                if (File.Exists(destinationFile))
                {
                    // Overwrite if the file is older than the source file.
                    if (File.GetLastWriteTime(file) > File.GetLastWriteTime(destinationFile))
                    {
                        File.Copy(file, destinationFile, true);
                    }
                }
                else
                {
                    File.Copy(file, destinationFile);
                }
            }

            Debug.Log("File synchronization completed successfully.");
        }
        catch (Exception ex)
        {
            Debug.LogError("An error occurred during file synchronization: " + ex.Message);
        }
    }

    /// <summary>
    /// Creates a backup of the source directory to the destination directory.
    /// </summary>
    public void BackupFiles()
    {
        try
        {
            if (!Directory.Exists(sourcePath))
            {
                Debug.LogError("Source directory does not exist: " + sourcePath);
                return;
            }

            string backupPath = Path.Combine(destinationPath, "Backup");
            if (!Directory.Exists(backupPath))
            {
                Directory.CreateDirectory(backupPath);
            }

            DirectoryInfo sourceDirInfo = new DirectoryInfo(sourcePath);
            CopyDirectory(sourceDirInfo, new DirectoryInfo(backupPath));

            Debug.Log("Backup completed successfully.");
        }
        catch (Exception ex)
        {
            Debug.LogError("An error occurred during backup: " + ex.Message);
        }
    }

    /// <summary>
    /// Copies the entire directory specified by sourceDir to a backup directory.
    /// </summary>
    /// <param name="sourceDir">The source directory to copy from.</param>
    /// <param name="destinationDir">The destination directory to copy to.</param>
    private void CopyDirectory(DirectoryInfo sourceDir, DirectoryInfo destinationDir)
    {
        // Get the files in the source directory and copy them to the backup directory.
        foreach (var file in sourceDir.GetFiles())
        {
            string destFile = Path.Combine(destinationDir.FullName, file.Name);
            file.CopyTo(destFile, false);
        }

        // To copy subdirectories, you need to get the subdirectories and call CopyDirectory recursively.
        foreach (var subdir in sourceDir.GetDirectories())
        {
            string destSubDir = Path.Combine(destinationDir.FullName, subdir.Name);
            Directory.CreateDirectory(destSubDir);
            CopyDirectory(subdir, new DirectoryInfo(destSubDir));
        }
    }
}
