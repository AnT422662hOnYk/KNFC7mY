// 代码生成时间: 2025-08-09 22:48:49
using System;
using System.Text.RegularExpressions;
using UnityEngine;

/// <summary>
/// A utility class for protecting against XSS attacks in Unity.
/// </summary>
public static class XssProtection
{
    /// <summary>
    /// Removes potentially harmful characters and sequences from input strings to prevent XSS attacks.
    /// </summary>
    /// <param name="input">The input string that may contain XSS attacks.</param>
    /// <returns>A sanitized string that is safe to display.</returns>
    public static string SanitizeInput(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            // If the input is null or empty, just return an empty string.
            return "";
        }

        // Define regex patterns for common XSS attack vectors.
        string scriptPattern = @