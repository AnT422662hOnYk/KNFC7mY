// 代码生成时间: 2025-08-05 18:01:39
 * 作者: [Your Name]
 * 创建日期: [Creation Date]
 */
using System;
using System.Diagnostics;
using UnityEngine;

/// <summary>
/// 内存分析器，用于监控和报告Unity应用程序的内存使用情况。
/// </summary>
public class MemoryAnalyzer : MonoBehaviour
{
    /// <summary>
    /// 每秒更新内存使用情况的次数。
    /// </summary>
    private int updateRate = 1; // 每秒更新一次

    /// <summary>
    /// 上次更新的时间。
    /// </summary>
    private float lastUpdateTime;

    /// <summary>
    /// 用于存储当前内存使用的量。
    /// </summary>
    private float currentMemoryUsage;

    /// <summary>
    /// 用于存储最大内存使用的量。
    /// </summary>
    private float maxMemoryUsage;

    /// <summary>
    /// 用于存储最小内存使用的量。
    /// </summary>
    private float minMemoryUsage;

    void Start()
    {
        // 初始化最大和最小内存使用量
        maxMemoryUsage = float.MinValue;
        minMemoryUsage = float.MaxValue;
    }

    void Update()
    {
        // 检查是否到了更新内存使用情况的时间
        if ((Time.time - lastUpdateTime) > (1.0f / updateRate))
        {
            UpdateMemoryUsage();
            lastUpdateTime = Time.time;
        }
    }

    /// <summary>
    /// 更新内存使用情况的方法。
    /// </summary>
    private void UpdateMemoryUsage()
    {
        try
        {
            // 获取当前进程
            Process currentProcess = Process.GetCurrentProcess();

            // 获取当前内存使用量
            currentMemoryUsage = currentProcess.WorkingSet64;

            // 更新最大和最小内存使用量
            if (currentMemoryUsage > maxMemoryUsage)
                maxMemoryUsage = currentMemoryUsage;
            if (currentMemoryUsage < minMemoryUsage)
                minMemoryUsage = currentMemoryUsage;

            // 打印内存使用情况
            Debug.Log($"Current Memory Usage: {currentMemoryUsage / 1024} KB");
            Debug.Log($"Max Memory Usage: {maxMemoryUsage / 1024} KB");
            Debug.Log($"Min Memory Usage: {minMemoryUsage / 1024} KB");
        }
        catch (Exception e)
        {
            // 错误处理
            Debug.LogError($"Failed to update memory usage: {e.Message}");
        }
    }

    // 可以添加其他方法来扩展功能，例如保存内存使用数据，发送警告等。
}
