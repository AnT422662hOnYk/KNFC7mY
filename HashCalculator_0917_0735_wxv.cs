// 代码生成时间: 2025-09-17 07:35:38
using System;
using System.Security.Cryptography;
using System.Text;

// 哈希值计算工具类
public class HashCalculator
{
    /// <summary>
    /// 计算字符串的哈希值
    /// </summary>
    /// <param name="inputString">输入的字符串</param>
    /// <param name="hashAlgorithm">使用的哈希算法</param>
    /// <returns>哈希值的16进制字符串</returns>
    public static string CalculateHash(string inputString, HashAlgorithm hashAlgorithm)
    {
        if (string.IsNullOrEmpty(inputString))
        {
            throw new ArgumentException("输入字符串不能为空", nameof(inputString));
        }

        if (hashAlgorithm == null)
        {
            throw new ArgumentNullException(nameof(hashAlgorithm), "哈希算法不能为空");
        }

        // 将输入字符串转换为字节数组
        byte[] inputBytes = Encoding.UTF8.GetBytes(inputString);

        // 使用哈希算法计算哈希值
        byte[] hashBytes = hashAlgorithm.ComputeHash(inputBytes);

        // 将哈希值转换为16进制字符串
        StringBuilder hashStringBuilder = new StringBuilder();
        foreach (byte b in hashBytes)
        {
            hashStringBuilder.Append(b.ToString("x2"));
        }

        return hashStringBuilder.ToString();
    }

    /// <summary>
    /// 打印哈希值计算结果
    /// </summary>
    /// <param name="inputString">输入的字符串</param>
    /// <param name="hashAlgorithm">使用的哈希算法</param>
    public static void PrintHashResult(string inputString, HashAlgorithm hashAlgorithm)
    {
        try
        {
            string hash = CalculateHash(inputString, hashAlgorithm);
            Console.WriteLine($"输入字符串: {inputString}");
            Console.WriteLine($"哈希值: {hash}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"计算哈希值时发生错误: {ex.Message}");
        }
    }

    // 主函数，仅用于演示哈希值计算工具的使用
    public static void Main(string[] args)
    {
        // 使用SHA256算法计算哈希值
        using (SHA256 sha256 = SHA256.Create())
        {
            PrintHashResult("Hello, World!", sha256);
        }
    }
}