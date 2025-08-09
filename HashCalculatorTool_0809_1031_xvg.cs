// 代码生成时间: 2025-08-09 10:31:21
using System;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;

public class HashCalculatorTool : MonoBehaviour
{
    // Calculates the SHA256 hash of the given input string.
    public string CalculateSha256Hash(string input)
    {
        try
        {
            // Use a SHA256 hash algorithm to compute the hash value.
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Compute the hash.
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

                // Convert byte array to a string.
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
        catch (Exception ex)
        {
            // Log the error and return null.
            Debug.LogError("Error calculating hash: " + ex.Message);
            return null;
        }
    }

    // Optional: A method to demonstrate hash calculation in the Unity console.
    private void Start()
    {
        string hash = CalculateSha256Hash("Hello, World!");
        if (hash != null)
        {
            Debug.Log("The SHA256 hash is: " + hash);
        }
    }
}
