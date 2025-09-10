// 代码生成时间: 2025-09-11 06:51:28
using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 数据统计分析器，用于处理和分析数据
/// </summary>
public class DataAnalyzer
{
    /// <summary>
    /// 分析数据并返回统计结果
    /// </summary>
    /// <param name="data">待分析的数据列表</param>
    /// <returns>统计结果</returns>
    public Dictionary<string, double> AnalyzeData(List<double> data)
    {
        // 检查数据列表是否为空
        if (data == null || data.Count == 0)
        {
            Debug.LogError("数据列表为空，无法进行分析");
            return null;
        }

        Dictionary<string, double> results = new Dictionary<string, double>();

        try
        {
            // 计算平均值
            results["Average"] = CalculateAverage(data);

            // 计算中位数
            results["Median"] = CalculateMedian(data);

            // 计算最大值
            results["Max"] = CalculateMax(data);

            // 计算最小值
            results["Min"] = CalculateMin(data);
        }
        catch (Exception ex)
        {
            Debug.LogError($"数据分析过程中发生错误：{ex.Message}");
            return null;
        }

        return results;
    }

    /// <summary>
    /// 计算数据列表的平均值
    /// </summary>
    /// <param name="data">数据列表</param>
    /// <returns>平均值</returns>
    private double CalculateAverage(List<double> data)
    {
        double sum = 0;
        foreach (double num in data)
        {
            sum += num;
        }
        return sum / data.Count;
    }

    /// <summary>
    /// 计算数据列表的中位数
    /// </summary>
    /// <param name="data">数据列表</param>
    /// <returns>中位数</returns>
    private double CalculateMedian(List<double> data)
    {
        int size = data.Count;
        int middle = size / 2;
        data.Sort();
        if (size % 2 == 0)
        {
            return (data[middle - 1] + data[middle]) / 2;
        }
        else
        {
            return data[middle];
        }
    }

    /// <summary>
    /// 计算数据列表的最大值
    /// </summary>
    /// <param name="data">数据列表</param>
    /// <returns>最大值</returns>
    private double CalculateMax(List<double> data)
    {
        return data.Max();
    }

    /// <summary>
    /// 计算数据列表的最小值
    /// </summary>
    /// <param name="data">数据列表</param>
    /// <returns>最小值</returns>
    private double CalculateMin(List<double> data)
    {
        return data.Min();
    }
}
