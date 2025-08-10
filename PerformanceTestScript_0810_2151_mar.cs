// 代码生成时间: 2025-08-10 21:51:17
using System;
using System.Diagnostics;
using UnityEngine;

/// <summary>
/// PerformanceTestScript encapsulates functionality for performance testing.
/// </summary>
public class PerformanceTestScript : MonoBehaviour
{
    private float startTime;
    private float duration;
    private int frameCount;

    /// <summary>
    /// Initializes the performance test.
    /// </summary>
    private void Start()
    {
        startTime = Time.realtimeSinceStartup;
        frameCount = 0;
    }

    /// <summary>
    /// Updates parameters each frame.
    /// </summary>
    private void Update()
    {
        frameCount++;
        duration = Time.realtimeSinceStartup - startTime;
    }

    /// <summary>
    /// Calculates the frames per second (FPS).
    /// </summary>
    /// <returns>Frames per second.</returns>
    public float CalculateFPS()
    {
        return frameCount / duration;
    }

    /// <summary>
    /// Logs performance data to the console.
    /// </summary>
    public void LogPerformance()
    {
        try
        {
            float fps = CalculateFPS();
            Debug.Log($"FPS: {fps}, Time since start: {duration}s");
        }
        catch (Exception ex)
        {
            Debug.LogError($"Error logging performance data: {ex.Message}");
        }
    }

    /// <summary>
    /// Ends the performance test and logs a summary.
    /// </summary>
    public void EndPerformanceTest()
    {
        float fps = CalculateFPS();
        Debug.Log($"Performance Test Completed. Average FPS: {fps}. Total frames rendered: {frameCount}. Time elapsed: {duration}s");
    }
}
