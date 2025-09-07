// 代码生成时间: 2025-09-07 08:37:31
using System;
using UnityEngine;

/// <summary>
/// RandomNumberGenerator provides a simple way to generate random numbers within a specified range.
/// </summary>
public class RandomNumberGenerator : MonoBehaviour
{
    /// <summary>
    /// Generates a random integer within the specified range.
    /// </summary>
    /// <param name="minValue">The minimum value of the range (inclusive).</param>
    /// <param name="maxValue">The maximum value of the range (inclusive).</param>
    /// <returns>A random integer within the specified range.</returns>
    public int GenerateRandomInt(int minValue, int maxValue)
    {
        if (maxValue < minValue)
        {
            Debug.LogError("maxValue cannot be less than minValue");
            return 0; // Return a default value in case of an error
        }

        return UnityEngine.Random.Range(minValue, maxValue + 1);
    }

    /// <summary>
    /// Generates a random float within the specified range.
    /// </summary>
    /// <param name="minValue">The minimum value of the range (inclusive).</param>
    /// <param name="maxValue">The maximum value of the range (inclusive).</param>
    /// <returns>A random float within the specified range.</returns>
    public float GenerateRandomFloat(float minValue, float maxValue)
    {
        if (maxValue < minValue)
        {
            Debug.LogError("maxValue cannot be less than minValue");
            return 0f; // Return a default value in case of an error
        }

        return UnityEngine.Random.Range(minValue, maxValue);
    }

    /// <summary>
    /// Example method to demonstrate the usage of random number generator.
    /// </summary>
    private void Start()
    {
        try
        {
            int randomInt = GenerateRandomInt(1, 10);
            float randomFloat = GenerateRandomFloat(0.0f, 1.0f);
            Debug.Log($"Random Int: {randomInt}, Random Float: {randomFloat}");
        }
        catch (Exception ex)
        {
            Debug.LogError($"An error occurred: {ex.Message}");
        }
    }
}