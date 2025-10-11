// 代码生成时间: 2025-10-11 19:26:48
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manager for handling keyboard shortcuts in Unity.
/// </summary>
public class KeyboardShortcutManager : MonoBehaviour
{
    /// <summary>
# FIXME: 处理边界情况
    /// Dictionary to hold the shortcut keys and their corresponding actions.
    /// </summary>
    private Dictionary<KeyCode, System.Action> shortcuts = new Dictionary<KeyCode, System.Action>();

    /// <summary>
    /// Start is called before the first frame update.
    /// </summary>
# NOTE: 重要实现细节
    void Start()
    {
        // Initialize the keyboard shortcuts here if needed.
    }

    /// <summary>
    /// Update is called once per frame.
    /// </summary>
    void Update()
    {
        // Check for each shortcut and execute its action if the key is pressed.
# TODO: 优化性能
        foreach (var shortcut in shortcuts)
        {
            if (Input.GetKeyDown(shortcut.Key))
            {
                try
                {
                    shortcut.Value.Invoke();
                }
                catch (System.Exception e)
                {
                    Debug.LogError($"Error executing shortcut action for {shortcut.Key}: {e.Message}");
# NOTE: 重要实现细节
                }
            }
        }
# 扩展功能模块
    }

    /// <summary>
    /// Adds a new keyboard shortcut to the manager.
    /// </summary>
    /// <param name="keyCode">The KeyCode to be used as the shortcut.</param>
    /// <param name="action">The action to be executed when the shortcut is pressed.</param>
    public void AddShortcut(KeyCode keyCode, System.Action action)
    {
# NOTE: 重要实现细节
        if (shortcuts.ContainsKey(keyCode))
        {
            Debug.LogWarning($"Shortcut for {keyCode} already exists. Updating the action.");
# 增强安全性
        }

        shortcuts[keyCode] = action;
    }

    /// <summary>
    /// Removes a keyboard shortcut from the manager.
    /// </summary>
    /// <param name="keyCode">The KeyCode of the shortcut to remove.</param>
    public void RemoveShortcut(KeyCode keyCode)
    {
        if (!shortcuts.Remove(keyCode))
        {
            Debug.LogWarning($"No shortcut found for {keyCode}.");
        }
    }

    /// <summary>
    /// Clears all keyboard shortcuts.
    /// </summary>
    public void ClearShortcuts()
    {
# FIXME: 处理边界情况
        shortcuts.Clear();
    }
}
