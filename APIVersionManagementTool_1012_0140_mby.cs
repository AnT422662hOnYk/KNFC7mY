// 代码生成时间: 2025-10-12 01:40:27
// <summary>
// A tool for managing API versions in a Unity project.
// </summary>
using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.IO;

// Define a class to represent an API version.
public class APIVersion
{
    public string VersionNumber;
    public string ChangeLog;
    public bool IsActive;

    // Constructor for an APIVersion with basic initialization.
    public APIVersion(string versionNumber, string changeLog, bool isActive)
    {
        VersionNumber = versionNumber;
        ChangeLog = changeLog;
        IsActive = isActive;
    }
}

// Define the main class for the API Version Management Tool.
public class APIVersionManagementTool
{
    private const string VersionFileName = "APIVersions.json";
    private List<APIVersion> apiVersions;

    // Load API versions from a JSON file.
    public void LoadAPIVersions()
    {
        if (!File.Exists(VersionFileName))
        {
            Debug.LogError("API versions file not found.");
            return;
        }

        string json = File.ReadAllText(VersionFileName);
        apiVersions = JsonUtility.FromJson<List<APIVersion>>(json);
    }

    // Save API versions to a JSON file.
    public void SaveAPIVersions()
    {
        if (apiVersions == null)
        {
            Debug.LogError("API versions list is not initialized.");
            return;
        }

        string json = JsonUtility.ToJson(apiVersions);
        File.WriteAllText(VersionFileName, json);
    }

    // Add a new API version.
    public void AddAPIVersion(string versionNumber, string changeLog)
    {
        if (apiVersions == null)
        {
            apiVersions = new List<APIVersion>();
        }

        apiVersions.Add(new APIVersion(versionNumber, changeLog, true));
        SaveAPIVersions();
    }

    // Activate or deactivate an API version.
    public void SetAPIVersionActive(string versionNumber, bool isActive)
    {
        if (apiVersions == null)
        {
            Debug.LogError("API versions list is not initialized.");
            return;
        }

        var version = apiVersions.FirstOrDefault(v => v.VersionNumber == versionNumber);
        if (version == null)
        {
            Debug.LogError("API version not found.");
            return;
        }

        version.IsActive = isActive;
        SaveAPIVersions();
    }
}
