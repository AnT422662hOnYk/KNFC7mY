// 代码生成时间: 2025-09-01 23:27:03
using System;
using System.IO;
using System.Collections.Generic;

public class FileBackupSyncTool
{
    private string sourcePath;
    private string backupPath;

    /**
     * 构造函数，初始化源路径和备份路径
     * 
     * @param sourcePath 源文件路径
     * @param backupPath 备份文件路径
     */
    public FileBackupSyncTool(string sourcePath, string backupPath)
    {
        this.sourcePath = sourcePath;
        this.backupPath = backupPath;
    }

    /**
     * 备份文件
     * 将源路径下的文件复制到备份路径
     * 
     * @param filename 需要备份的文件名
     */
    public void BackupFile(string filename)
    {
        try
        {
            string sourceFilePath = Path.Combine(sourcePath, filename);
            string backupFilePath = Path.Combine(backupPath, filename);

            if (!File.Exists(sourceFilePath))
            {
                throw new FileNotFoundException($"源路径下未找到文件：{sourceFilePath}");
            }

            File.Copy(sourceFilePath, backupFilePath, true);
            Console.WriteLine($"文件 {filename} 已成功备份到 {backupPath}。");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"备份文件时出错：{ex.Message}");
        }
    }

    /**
     * 同步文件
     * 比较源路径和备份路径下的文件，同步差异
     */
    public void SyncFiles()
    {
        try
        {
            // 获取源路径和备份路径下的所有文件
            IEnumerable<string> sourceFiles = Directory.EnumerateFiles(sourcePath);
            IEnumerable<string> backupFiles = Directory.EnumerateFiles(backupPath);

            // 比较文件列表，同步差异
            foreach (string sourceFile in sourceFiles)
            {
                string filename = Path.GetFileName(sourceFile);
                if (!File.Exists(Path.Combine(backupPath, filename)))
                {
                    BackupFile(filename);
                }
            }

            foreach (string backupFile in backupFiles)
            {
                string filename = Path.GetFileName(backupFile);
                if (!File.Exists(Path.Combine(sourcePath, filename)))
                {
                    File.Delete(backupFile);
                    Console.WriteLine($"已删除多余的备份文件：{filename}。");
                }
            }

            Console.WriteLine("sync操作完毕。");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"同步文件时出错：{ex.Message}");
        }
    }
}
