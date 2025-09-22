// 代码生成时间: 2025-09-22 10:35:43
using System;
using UnityEngine;
using System.Net;

/// <summary>
/// A utility class for validating the format and reachability of URLs.
/// </summary>
public class UrlValidator
{
    /// <summary>
    /// Validates whether a given URL is in a valid format and is reachable.
    /// </summary>
    /// <param name="url">The URL to validate.</param>
    /// <returns>true if the URL is valid and reachable, false otherwise.</returns>
    public static bool ValidateUrl(string url)
    {
        // Check if the URL is null or empty
        if (string.IsNullOrEmpty(url))
        {
            Debug.LogError("The provided URL is null or empty.");
            return false;
        }

        // Try to create a Uri object from the URL to validate its format
        try
        {
            Uri uriResult;
            bool result = Uri.TryCreate(url, UriKind.Absolute, out uriResult) &&
                         (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
            if (!result)
            {
                Debug.LogError("The provided URL is not in a valid format.");
                return false;
            }

            // Check if the URL is reachable
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uriResult);
            request.Timeout = 5000; // 5 seconds
            request.Method = "HEAD";
            try
            {
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        Debug.Log("The URL is valid and reachable.");
                        return true;
                    }
                    else
                    {
                        Debug.LogError($"The URL is reachable but returned a status code of {response.StatusCode}.");
                        return false;
                    }
                }
            }
            catch (WebException ex)
            {
                // Handle exceptions related to network issues
                Debug.LogError($"Could not reach the URL: {ex.Message}");
                return false;
            }
        }
        catch (UriFormatException)
        {
            // Handle cases where the URL format is incorrect
            Debug.LogError("The provided URL is not in a valid format.");
            return false;
        }
    }
}
