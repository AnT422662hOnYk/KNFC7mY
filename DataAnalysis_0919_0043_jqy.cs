// 代码生成时间: 2025-09-19 00:43:00
// <summary>
// DataAnalysis.cs: A Unity C# script that serves as a data analysis tool.
// </summary>

using System;
using UnityEngine;
using System.Collections.Generic;

public class DataAnalysis : MonoBehaviour
{
    // <summary>
    // Method to analyze data and provide statistics.
    // </summary>
    // <param name="data">The list of numerical data to analyze.</param>
    // <returns>Returns a dictionary containing data statistics.</returns>
    public Dictionary<string, float> AnalyzeData(List<float> data)
    {
        if (data == null || data.Count == 0)
        {
            Debug.LogError("DataAnalysis: No data provided for analysis.");
            return null;
        }

        float sum = 0f, max = float.MinValue, min = float.MaxValue;
        float mean = 0f, variance = 0f, stdDeviation = 0f;
        int count = data.Count;

        // Calculate sum, max, min, and mean.
        foreach (float val in data)
        {
            sum += val;
            max = Math.Max(max, val);
            min = Math.Min(min, val);
        }
        mean = sum / count;

        // Calculate variance and standard deviation.
        foreach (float val in data)
        {
            variance += (val - mean) * (val - mean);
        }
        variance /= count;
        stdDeviation = Mathf.Sqrt(variance);

        // Return statistics in a dictionary.
        Dictionary<string, float> stats = new Dictionary<string, float>
        {
            { "Sum", sum },
            { "Max", max },
            { "Min", min },
            { "Mean", mean },
            { "Variance", variance },
            { "Standard Deviation", stdDeviation }
        };

        return stats;
    }

    // <summary>
    // Method to display the data statistics in the Unity console.
    // </summary>
    // <param name="data">The list of numerical data to display statistics for.</param>
    public void DisplayDataStatistics(List<float> data)
    {
        Dictionary<string, float> stats = AnalyzeData(data);
        if (stats != null)
        {
            foreach (KeyValuePair<string, float> entry in stats)
            {
                Debug.Log($"Statistic: {entry.Key}, Value: {entry.Value}");
            }
        }
    }

    // <summary>
    // Start is called before the first frame update.
    // </summary>
    void Start()
    {
        // Example data for analysis.
        List<float> sampleData = new List<float> { 1.2f, 2.5f, 3.7f, 4.1f, 5.3f };
        // Displaying statistics for the sample data.
        DisplayDataStatistics(sampleData);
    }
}
