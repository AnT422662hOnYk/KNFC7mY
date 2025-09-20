// 代码生成时间: 2025-09-20 20:20:40
using System;
using System.Diagnostics;
using UnityEngine;

/// <summary>
/// A class to analyze memory usage in a Unity application.
/// </summary>
public class MemoryAnalysis
{
    /// <summary>
    /// Gets the total memory usage of the application.
    /// </summary>
    /// <returns>The total memory usage in bytes.</returns>
    public static long GetTotalMemoryUsage()
    {
        try
        {
            // Get the total memory in bytes
            long totalMemory = GC.GetTotalMemory(false);
            return totalMemory;
        }
        catch (Exception ex)
        {
            // Log the exception and return -1 to indicate failure
            Debug.LogError($"Failed to get total memory usage: {ex.Message}");
            return -1;
        }
    }

    /// <summary>
    /// Gets the memory usage of the application in a human-readable format.
    /// </summary>
    /// <returns>The memory usage in a formatted string.</returns>
    public static string GetFormattedMemoryUsage()
    {
        try
        {
            // Get the total memory in bytes
            long totalMemory = GetTotalMemoryUsage();
            if (totalMemory == -1)
            {
                return "Failed to get memory usage.";
            }

            // Convert bytes to a more readable format (e.g., KB, MB, GB)
            if (totalMemory < 1024)
            {
                return $"Memory usage: {totalMemory} B";
            }
            else if (totalMemory < 1024 * 1024)
            {
                return $"Memory usage: {totalMemory / 1024} KB";
            }
            else if (totalMemory < 1024 * 1024 * 1024)
            {
                return $"Memory usage: {totalMemory / (1024 * 1024)} MB";
            }
            else
            {
                return $"Memory usage: {totalMemory / (1024 * 1024 * 1024)} GB";
            }
        }
        catch (Exception ex)
        {
            // Log the exception and return a failure message
            Debug.LogError($"Failed to get formatted memory usage: {ex.Message}");
            return "Failed to get formatted memory usage.";
        }
    }

    /// <summary>
    /// Forces a garbage collection to clean up unused memory.
    /// </summary>
    public static void ForceGarbageCollection()
    {
        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.Collect();
    }
}
