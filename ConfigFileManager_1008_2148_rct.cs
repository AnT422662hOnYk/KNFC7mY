// 代码生成时间: 2025-10-08 21:48:58
 * error handling and documentation for maintainability and scalability.
 */

using System;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;

/// <summary>
/// Configuration file manager class.
/// </summary>
public class ConfigFileManager
{
    private readonly string configFilePath;

    /// <summary>
    /// Initializes a new instance of the ConfigFileManager class.
    /// </summary>
    /// <param name="configFilePath">Path to the configuration file.</param>
    public ConfigFileManager(string configFilePath)
    {
        this.configFilePath = configFilePath;
    }

    /// <summary>
    /// Loads the configuration data from the file.
    /// </summary>
    /// <typeparam name="T">The type of the configuration data.</typeparam>
    /// <returns>The configuration data of type T.</returns>
    public T LoadConfig<T>()
    {
        try
        {
            if (File.Exists(configFilePath))
            {
                string configData = File.ReadAllText(configFilePath);
                return JsonConvert.DeserializeObject<T>(configData);
            }
            else
            {
                Debug.LogError("Configuration file not found.");
                return default(T);
            }
        }
        catch (Exception e)
        {
            Debug.LogError($"Error loading configuration: {e.Message}");
            return default(T);
        }
    }

    /// <summary>
    /// Saves the configuration data to the file.
    /// </summary>
    /// <param name="configData">The configuration data to be saved.</param>
    public void SaveConfig<T>(T configData)
    {
        try
        {
            string configDataString = JsonConvert.SerializeObject(configData, Formatting.Indented);
            File.WriteAllText(configFilePath, configDataString);
        }
        catch (Exception e)
        {
            Debug.LogError($"Error saving configuration: {e.Message}");
        }
    }
}
