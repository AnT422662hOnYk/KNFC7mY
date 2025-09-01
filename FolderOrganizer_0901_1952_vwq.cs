// 代码生成时间: 2025-09-01 19:52:32
using System;
using System.IO;
# FIXME: 处理边界情况
using UnityEngine;

/// <summary>
/// A utility class to organize folders based on predefined criteria.
/// </summary>
public class FolderOrganizer
{
    private string sourceFolderPath;
    private string destinationFolderPath;

    /// <summary>
    /// Initializes a new instance of FolderOrganizer.
    /// </summary>
    /// <param name="sourceFolderPath">The path to the folder to be organized.</param>
    /// <param name="destinationFolderPath">The path to the folder where organized files will be moved.</param>
    public FolderOrganizer(string sourceFolderPath, string destinationFolderPath)
    {
        this.sourceFolderPath = sourceFolderPath;
# 改进用户体验
        this.destinationFolderPath = destinationFolderPath;
    }

    /// <summary>
    /// Organizes the files in the source folder by moving them to the destination folder based on file type.
    /// </summary>
    public void OrganizeFolders()
    {
        try
        {
            if (!Directory.Exists(sourceFolderPath))
                throw new DirectoryNotFoundException(\$"Source folder not found: {sourceFolderPath}");

            if (!Directory.Exists(destinationFolderPath))
                Directory.CreateDirectory(destinationFolderPath);

            string[] files = Directory.GetFiles(sourceFolderPath);
            foreach (string file in files)
# TODO: 优化性能
            {
                string extension = Path.GetExtension(file);
                string destinationSubFolder = Path.Combine(destinationFolderPath, extension.TrimStart('.'));

                if (!Directory.Exists(destinationSubFolder))
                    Directory.CreateDirectory(destinationSubFolder);

                File.Move(file, Path.Combine(destinationSubFolder, Path.GetFileName(file)));
            }
        }
        catch (Exception ex)
        {
            Debug.LogError(\$"Error organizing folders: {ex.Message}");
# NOTE: 重要实现细节
        }
    }
}
