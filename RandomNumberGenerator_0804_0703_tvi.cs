// 代码生成时间: 2025-08-04 07:03:28
// RandomNumberGenerator.cs
// 这个类提供了一个随机数生成器，用于生成指定范围内的随机数。
using System;

namespace UnityRandomGenerator
{
    // RandomNumberGenerator 类包含了生成随机数的方法。
    public class RandomNumberGenerator
    {
        private Random _random;

        // 构造函数初始化随机数生成器。
        public RandomNumberGenerator()
        {
            _random = new Random();
        }

        // GenerateRandomNumber 方法生成一个在指定范围内的随机数。
        // 参数 min 和 max 分别指定随机数的最小值和最大值。
        public int GenerateRandomNumber(int min, int max)
        {
            // 检查参数以确保 max 大于 min，否则抛出异常。
            if (min >= max)
            {
                throw new ArgumentException("max must be greater than min.");
            }

            // 返回一个在 [min, max] 范围内的随机整数。
            return _random.Next(min, max + 1);
        }
    }
}
