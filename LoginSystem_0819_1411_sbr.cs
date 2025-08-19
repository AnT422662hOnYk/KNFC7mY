// 代码生成时间: 2025-08-19 14:11:43
// <summary>
// 登录验证系统
// </summary>
using System;
using UnityEngine;
using System.Collections.Generic;

public class LoginSystem
{
    private Dictionary<string, string> userDatabase = new Dictionary<string, string>();

    // 初始化用户数据库
    public LoginSystem()
    {
        // 这里可以添加一些预设的用户信息，实际项目中应从数据库或文件中加载
        userDatabase.Add("user1", "password1");
        userDatabase.Add("user2", "password2");
    }

    // 用户登录验证方法
    public bool ValidateUser(string username, string password)
    {
        try
        {
            // 检查用户名是否在用户数据库中
            if (!userDatabase.ContainsKey(username))
            {
                Debug.LogError("Username not found");
                return false;
            }

            // 检查密码是否正确
            if (userDatabase[username] != password)
            {
                Debug.LogError("Incorrect password");
                return false;
            }

            // 用户名和密码都正确，返回true
            return true;
        }
        catch (Exception ex)
        {
            Debug.LogError($"Error occurred during user validation: {ex.Message}");
            return false;
        }
    }

    // 添加用户方法
    public bool AddUser(string username, string password)
    {
        try
        {
            if (userDatabase.ContainsKey(username))
            {
                Debug.LogError("User already exists");
                return false;
            }

            userDatabase.Add(username, password);
            return true;
        }
        catch (Exception ex)
        {
            Debug.LogError($"Error occurred while adding user: {ex.Message}");
            return false;
        }
    }
}
