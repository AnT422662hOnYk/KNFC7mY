// 代码生成时间: 2025-08-03 18:55:01
using System;
using UnityEngine;
using System.Net;

public class UrlValidator
{
    // Validate the URL format using regular expressions.
    private static readonly string UrlRegex = @"^(http|https)://[a-zA-Z0-9.-]+\.[a-zA-Z]{2,6}(:[0-9]*)?/?$";

    // Method to check if the URL is valid.
    // Returns true if the URL is valid, false otherwise.
    public static bool IsValidUrl(string url)
    {
        try
        {
            // Use Uri to check if the URL is well-formed.
            Uri uriResult;
            bool result = Uri.TryCreate(url, UriKind.Absolute, out uriResult)
                && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);

            // Check if the URL matches the regular expression for further validation.
            return result && System.Text.RegularExpressions.Regex.IsMatch(url, UrlRegex);
        }
        catch (Exception e)
        {
            // Log the exception and return false if an error occurs.
            Debug.LogError("Error validating URL: " + e.Message);
            return false;
        }
    }

    // Example method to use the IsValidUrl function.
    // This method could be called from Unity's Update method or any other part of the game logic.
    public static void CheckUrl(string url)
    {
        if (IsValidUrl(url))
        {
            Debug.Log("The URL is valid: " + url);
        }
        else
        {
            Debug.Log("The URL is invalid: " + url);
        }
    }
}