// 代码生成时间: 2025-09-18 08:11:35
// HashCalculator.cs
// 该类提供了一个哈希值计算工具，能够计算字符串的哈希值。

using System;
using System.Security.Cryptography;
using UnityEngine;

namespace YourNamespace
{
    public class HashCalculator
    {
        // 计算字符串的MD5哈希值
        public string CalculateMD5Hash(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                Debug.LogError("Input string is null or empty.");
                return null;
            }

            using (var md5 = MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant();
            }
        }

        // 计算字符串的SHA256哈希值
        public string CalculateSHA256Hash(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                Debug.LogError("Input string is null or empty.");
                return null;
            }

            using (var sha256 = SHA256.Create())
            {
                byte[] inputBytes = System.Text.Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = sha256.ComputeHash(inputBytes);
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant();
            }
        }
    }
}
