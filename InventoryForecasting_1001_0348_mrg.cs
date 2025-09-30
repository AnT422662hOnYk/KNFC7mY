// 代码生成时间: 2025-10-01 03:48:22
using System;
using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Inventory Forecasting Model
/// This class simulates a simple inventory forecasting system.
/// </summary>
public class InventoryForecasting
{
    private List<float> historicalSalesData;
    private float alpha; // Smoothing factor for exponential smoothing
    private float forecastedValue;

    /// <summary>
    /// Initializes a new instance of the InventoryForecasting class.
    /// </summary>
    /// <param name="historicData">List of historical sales data points.</param>
    /// <param name="smoothingFactor">The smoothing factor for exponential smoothing.</param>
    public InventoryForecasting(List<float> historicData, float smoothingFactor)
    {
        if (historicData == null || historicData.Count == 0)
            throw new ArgumentException("Historical data cannot be null or empty.");

        if (smoothingFactor <= 0 || smoothingFactor >= 1)
            throw new ArgumentOutOfRangeException("Smoothing factor must be between 0 and 1.");

        this.historicalSalesData = historicData;
        this.alpha = smoothingFactor;
        this.forecastedValue = CalculateInitialForecast();
    }

    /// <summary>
    /// Calculates the initial forecast based on the first historical data point.
    /// </summary>
    /// <returns>The initial forecast value.</returns>
    private float CalculateInitialForecast()
    {
        return historicalSalesData[0]; // Simple approach for initial forecast
    }

    /// <summary>
    /// Updates the forecast based on the latest actual sales data.
    /// </summary>
    /// <param name="actualSales">The actual sales data point to update the forecast.</param>
    public void UpdateForecast(float actualSales)
    {
        if (actualSales < 0)
            throw new ArgumentOutOfRangeException("Actual sales cannot be negative.");

        forecastedValue = (alpha * actualSales) + ((1 - alpha) * forecastedValue);
    }

    /// <summary>
    /// Gets the current forecasted value for inventory.
    /// </summary>
    /// <returns>The forecasted inventory value.</returns>
    public float GetForecastedValue()
    {
        return forecastedValue;
    }
}
