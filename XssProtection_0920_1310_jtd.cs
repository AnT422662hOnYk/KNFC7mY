// 代码生成时间: 2025-09-20 13:10:06
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

namespace XSSProtection
{
    public class XssProtection : MonoBehaviour
    {
        // 公共方法：清理输入文本以防止XSS攻击
        public string CleanInput(string input)
        {
            try
            {
                // 移除所有脚本标签
                input = Regex.Replace(input, "<script>.*?</script>","", RegexOptions.IgnoreCase | RegexOptions.Singleline);

                // 移除所有事件处理器
                input = Regex.Replace(input, "on[a-zA-Z]+\s*=(\"|\')*.*?(\"|\')*", "", RegexOptions.IgnoreCase);

                // 移除所有JavaScript URL
                input = Regex.Replace(input, "javascript:.*?;", "", RegexOptions.IgnoreCase);

                // 移除所有CSS表达式
                input = Regex.Replace(input, "expression\(.*?\)", "", RegexOptions.IgnoreCase);

                // 移除所有VBScript表达式
                input = Regex.Replace(input, "vbs:\".*?\"", "", RegexOptions.IgnoreCase);

                // 移除所有Flash表达式
                input = Regex.Replace(input, "flash:\".*?\"", "", RegexOptions.IgnoreCase);

                // 清理其他潜在的XSS攻击代码
                input = Regex.Replace(input, "<.*?>", "", RegexOptions.Singleline);

                return input;
            }
            catch (Exception ex)
            {
                Debug.LogError("Error cleaning input: " + ex.Message);
                return null;
            }
        }

        // 公共方法：校验输入是否包含潜在的XSS攻击代码
        public bool ContainsXss(string input)
        {
            // 使用正则表达式检查输入中是否包含XSS攻击代码
            bool containsScript = Regex.IsMatch(input, "<script>.*?</script>", RegexOptions.IgnoreCase | RegexOptions.Singleline);
            bool containsEvent = Regex.IsMatch(input, "on[a-zA-Z]+\s*=(\"|\')*.*?(\"|\')*", RegexOptions.IgnoreCase);
            bool containsJavaScriptUrl = Regex.IsMatch(input, "javascript:.*?;", RegexOptions.IgnoreCase);
            bool containsCssExpression = Regex.IsMatch(input, "expression\(.*?\)", RegexOptions.IgnoreCase);
            bool containsVbscriptExpression = Regex.IsMatch(input, "vbs:\".*?\"", RegexOptions.IgnoreCase);
            bool containsFlashExpression = Regex.IsMatch(input, "flash:\".*?\"", RegexOptions.IgnoreCase);
            bool containsHtmlTags = Regex.IsMatch(input, "<.*?>", RegexOptions.Singleline);

            // 如果输入包含任何XSS攻击代码，则返回true
            return containsScript || containsEvent || containsJavaScriptUrl || containsCssExpression ||
                   containsVbscriptExpression || containsFlashExpression || containsHtmlTags;
        }
    }
}
