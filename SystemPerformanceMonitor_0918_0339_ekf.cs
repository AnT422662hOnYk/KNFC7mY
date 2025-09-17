// 代码生成时间: 2025-09-18 03:39:09
using System;
using UnityEngine;
using UnityEngine.Profiling;

public class SystemPerformanceMonitor
{
    // Property to hold CPU usage
    public float CpuUsage { get; private set; }
    
    // Property to hold GPU usage
    public float GpuUsage { get; private set; }
    
    // Property to hold memory usage
    public float MemoryUsage { get; private set; }
    
    // Constructor
    public SystemPerformanceMonitor()
    {
        // Initialize properties
        CpuUsage = 0f;
        GpuUsage = 0f;
        MemoryUsage = 0f;
    }
    
    // Method to update system performance metrics
    public void UpdatePerformanceMetrics()
    {
        try
        {
            // Retrieve CPU usage
            float cpuUsage = Profiler.GetCPUUsagePercentage();
            CpuUsage = cpuUsage;
            
            // Retrieve GPU usage
            float gpuUsage = Profiler.GetGPUUsagePercentage();
            GpuUsage = gpuUsage;
            
            // Retrieve memory usage
            float memoryUsage = Profiler.GetTotalAllocatedMemoryLong() / (1024.0f * 1024.0f); // Convert to megabytes
            MemoryUsage = memoryUsage;
        }
        catch (Exception ex)
        {
            Debug.LogError("Error updating performance metrics: " + ex.Message);
        }
    }
    
    // Method to display system performance metrics
    public void DisplayPerformanceMetrics()
    {
        Debug.Log("CPU Usage: " + CpuUsage + "%");
        Debug.Log("GPU Usage: " + GpuUsage + "%");
        Debug.Log("Memory Usage: " + MemoryUsage + " MB");
    }
}
