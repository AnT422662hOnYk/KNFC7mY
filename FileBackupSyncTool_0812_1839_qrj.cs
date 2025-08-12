// 代码生成时间: 2025-08-12 18:39:37
using System;
using System.IO;
using System.Linq;
using UnityEngine;

/// <summary>
/// File backup and synchronization tool.
/// </summary>
# 优化算法效率
public class FileBackupSyncTool : MonoBehaviour
{
    /// <summary>
    /// The source directory.
    /// </summary>
    public string sourceDirectory;
# 添加错误处理
    /// <summary>
# 添加错误处理
    /// The destination directory.
    /// </summary>
    public string destinationDirectory;
# FIXME: 处理边界情况
    /// <summary>
    /// The backup directory.
    /// </summary>
    public string backupDirectory;

    private void Start()
    {
        // Call the backup and sync function on start.
        BackupAndSync();
    }

    /// <summary>
    /// Performs file backup and synchronization.
    /// </summary>
    public void BackupAndSync()
# 优化算法效率
    {
        // Ensure the source and destination directories are set.
        if (string.IsNullOrEmpty(sourceDirectory) || string.IsNullOrEmpty(destinationDirectory))
        {
            Debug.LogError("Source or destination directory is not set.");
            return;
        }

        // Create the backup directory if it doesn't exist.
# 优化算法效率
        if (!Directory.Exists(backupDirectory))
        {
            Directory.CreateDirectory(backupDirectory);
        }

        try
        {
            // Backup the source directory to the backup directory.
            BackupDirectory(sourceDirectory, backupDirectory);

            // Synchronize the source directory with the destination directory.
            SyncDirectories(sourceDirectory, destinationDirectory);
        }
        catch (Exception ex)
        {
            Debug.LogError($"Error during backup and sync: {ex.Message}");
        }
    }

    /// <summary>
    /// Backs up files from the source directory to the backup directory.
    /// </summary>
    /// <param name="sourcePath">The path of the source directory.</param>
    /// <param name="backupPath">The path of the backup directory.</param>
    private void BackupDirectory(string sourcePath, string backupPath)
    {
        // Copy all files from the source to the backup directory.
        foreach (var file in Directory.GetFiles(sourcePath))
        {
# 增强安全性
            var fileName = Path.GetFileName(file);
            var backupFile = Path.Combine(backupPath, fileName);
# NOTE: 重要实现细节
            File.Copy(file, backupFile, true);
        }
# 改进用户体验
    }

    /// <summary>
    /// Synchronizes the source directory with the destination directory.
# NOTE: 重要实现细节
    /// </summary>
    /// <param name="sourcePath">The path of the source directory.</param>
    /// <param name="destinationPath">The path of the destination directory.</param>
    private void SyncDirectories(string sourcePath, string destinationPath)
    {
        // Get all files from the source directory.
        var sourceFiles = Directory.GetFiles(sourcePath).Select(Path.GetFileName).ToList();

        // Get all files from the destination directory.
# 优化算法效率
        var destinationFiles = Directory.GetFiles(destinationPath).Select(Path.GetFileName).ToList();

        // Copy new or updated files from source to destination.
        foreach (var sourceFile in sourceFiles)
        {
            if (!destinationFiles.Contains(sourceFile))
            {
                var sourceFileFullPath = Path.Combine(sourcePath, sourceFile);
                var destinationFileFullPath = Path.Combine(destinationPath, sourceFile);
                File.Copy(sourceFileFullPath, destinationFileFullPath, true);
            }
        }

        // Remove files from destination that are not in source.
# NOTE: 重要实现细节
        foreach (var destinationFile in destinationFiles)
        {
            if (!sourceFiles.Contains(destinationFile))
            {
                var fileToDelete = Path.Combine(destinationPath, destinationFile);
                File.Delete(fileToDelete);
            }
# 优化算法效率
        }
# 扩展功能模块
    }
}
