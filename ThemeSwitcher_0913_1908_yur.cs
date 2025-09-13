// 代码生成时间: 2025-09-13 19:08:02
using System.Collections.Generic;
using UnityEngine;

/// <summary>
# 优化算法效率
/// This class handles theme switching functionality within a Unity project.
# 优化算法效率
/// </summary>
# 扩展功能模块
public class ThemeSwitcher : MonoBehaviour
{
    private static ThemeSwitcher _instance;
# NOTE: 重要实现细节
    public static ThemeSwitcher Instance
    {
        get
        {
            if (_instance == null)
            {
                // Find the existing instance or create a new one if it doesn't exist
                _instance = FindObjectOfType<ThemeSwitcher>();
                if (_instance == null)
                {
                    GameObject themeSwitcherObj = new GameObject("ThemeSwitcher");
                    _instance = themeSwitcherObj.AddComponent<ThemeSwitcher>();
                }
            }
            return _instance;
        }
    }

    [SerializeField] private List<Theme> themes;

    /// <summary>
# 优化算法效率
    /// The currently active theme.
    /// </summary>
    public Theme CurrentTheme { get; private set; }

    private void Awake()
    {
        // Ensure only one instance of ThemeSwitcher exists
# 扩展功能模块
        if (_instance != null && _instance != this)
# TODO: 优化性能
        {
            Destroy(gameObject);
# FIXME: 处理边界情况
            return;
        }
# 改进用户体验

        _instance = this;
        DontDestroyOnLoad(gameObject);

        // Initialize with the first theme by default
        InitializeTheme(themes[0]);
    }

    /// <summary>
    /// Switches to the specified theme.
    /// </summary>
# 添加错误处理
    /// <param name="themeName">The name of the theme to switch to.</param>
    public void SwitchTheme(string themeName)
    {
        foreach (Theme theme in themes)
        {
            if (theme.Name.Equals(themeName))
            {
# NOTE: 重要实现细节
                InitializeTheme(theme);
                return;
            }
        }
        Debug.LogError("Theme not found: " + themeName);
    }

    /// <summary>
# 增强安全性
    /// Initializes the theme by applying it to all relevant game objects.
    /// </summary>
    /// <param name="theme">The theme to apply.</param>
    private void InitializeTheme(Theme theme)
    {
        if (CurrentTheme != null)
# FIXME: 处理边界情况
        {
# 添加错误处理
            // Disable all color change scripts associated with the current theme
            CurrentTheme.Disable();
        }
# 优化算法效率

        // Apply the new theme
# 改进用户体验
        theme.Enable();
        CurrentTheme = theme;
        Debug.Log("Theme switched to: " + theme.Name);
# 优化算法效率
    }

    /// <summary>
    /// A simple struct to represent a theme.
    /// </summary>
    [System.Serializable]
    public struct Theme
    {
        public string Name;
        public Color Color;
        public List<SpriteRenderer> ColorChangeScripts;
# 增强安全性

        public void Enable()
        {
            foreach (SpriteRenderer script in ColorChangeScripts)
            {
                script.color = Color;
            }
        }

        public void Disable()
# 添加错误处理
        {
            foreach (SpriteRenderer script in ColorChangeScripts)
            {
                script.color = Color.white; // Reset to default color
            }
        }
# 扩展功能模块
    }
}
