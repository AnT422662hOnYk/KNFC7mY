// 代码生成时间: 2025-08-24 19:37:16
using System;
using System.Collections.Generic;
using UnityEngine;

// 数据统计分析器类
# 增强安全性
public class DataAnalyser
# 增强安全性
{
# NOTE: 重要实现细节
    private List<float> dataPoints;

    // 构造函数，初始化数据点列表
    public DataAnalyser()
    {
        dataPoints = new List<float>();
    }

    // 添加数据点
    public void AddDataPoint(float data)
    {
        // 确保数据是有效的
        if (float.IsNaN(data) || float.IsInfinity(data))
        {
            Debug.LogError("Invalid data point: " + data);
            return;
        }

        dataPoints.Add(data);
    }

    // 计算平均值
    public float CalculateAverage()
    {
        if (dataPoints.Count == 0)
        {
            Debug.LogError("No data points to calculate average.");
            return 0;
        }
# 添加错误处理

        float sum = 0;
        foreach (float value in dataPoints)
        {
            sum += value;
# 改进用户体验
        }

        return sum / dataPoints.Count;
    }
# 改进用户体验

    // 计算中位数
# 添加错误处理
    public float CalculateMedian()
    {
# 扩展功能模块
        if (dataPoints.Count == 0)
        {
            Debug.LogError("No data points to calculate median.");
            return 0;
        }

        dataPoints.Sort();
        int middle = dataPoints.Count / 2;
        return dataPoints.Count % 2 == 0 ?
# 添加错误处理
                (dataPoints[middle - 1] + dataPoints[middle]) / 2 : // 偶数个数据点
                dataPoints[middle]; // 奇数个数据点
    }

    // 计算最大值
    public float CalculateMax()
    {
        if (dataPoints.Count == 0)
        {
            Debug.LogError("No data points to calculate max.");
            return 0;
        }

        float max = dataPoints[0];
        foreach (float value in dataPoints)
        {
            if (value > max)
# 改进用户体验
            {
                max = value;
            }
        }

        return max;
    }

    // 计算最小值
    public float CalculateMin()
    {
        if (dataPoints.Count == 0)
        {
            Debug.LogError("No data points to calculate min.");
            return 0;
# FIXME: 处理边界情况
        }

        float min = dataPoints[0];
        foreach (float value in dataPoints)
        {
            if (value < min)
# TODO: 优化性能
            {
                min = value;
            }
        }

        return min;
# 增强安全性
    }

    // 清除所有数据点
    public void ClearDataPoints()
    {
        dataPoints.Clear();
    }
# 改进用户体验
}
# TODO: 优化性能
