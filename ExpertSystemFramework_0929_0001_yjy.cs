// 代码生成时间: 2025-09-29 00:01:43
using System;
using System.Collections.Generic;

/// <summary>
/// ExpertSystemFramework represents a basic framework for an expert system in Unity.
/// </summary>
public class ExpertSystemFramework
{
    private List<IExpertSystemModule> modules;

    /// <summary>
    /// Initializes a new instance of the ExpertSystemFramework class.
    /// </summary>
    public ExpertSystemFramework()
    {
        modules = new List<IExpertSystemModule>();
    }

    /// <summary>
    /// Adds a module to the expert system.
    /// </summary>
    /// <param name="module">The module to be added.</param>
    public void AddModule(IExpertSystemModule module)
    {
        if (module == null)
            throw new ArgumentNullException(nameof(module), "Module cannot be null.");

        modules.Add(module);
    }

    /// <summary>
    /// Removes a module from the expert system.
    /// </summary>
    /// <param name="module">The module to be removed.</param>
    public void RemoveModule(IExpertSystemModule module)
    {
        if (module == null)
            throw new ArgumentNullException(nameof(module), "Module cannot be null.");

        modules.Remove(module);
    }

    /// <summary>
    /// Provides a structured way to execute the expert system logic.
    /// </summary>
    /// <returns>A list of results from each module.</returns>
    public List<object> Execute()
    {
        var results = new List<object>();

        foreach (var module in modules)
        {
            try
            {
                results.Add(module.Process());
            }
            catch (Exception ex)
            {
                // Log the exception and continue with the next module
                UnityEngine.Debug.LogError($"Error processing module {module.GetType().Name}: {ex.Message}");
                results.Add(null); // Indicate failure with null
            }
        }

        return results;
    }
}

/// <summary>
/// Interface for expert system modules.
/// </summary>
public interface IExpertSystemModule
{
    /// <summary>
    /// Processes the module's logic.
    /// </summary>
    /// <returns>The result of the processing.</returns>
    object Process();
}
