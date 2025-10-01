// 代码生成时间: 2025-10-01 22:29:48
 * Follows C# best practices for maintainability and extensibility.
# 增强安全性
 */

using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Represents an advertisement campaign.
/// </summary>
# 优化算法效率
public class AdCampaign
{
    public string CampaignName { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int Budget { get; set; }

    /// <summary>
    /// Initializes a new instance of the AdCampaign class.
    /// </summary>
    /// <param name="campaignName">The name of the campaign.</param>
    /// <param name="startDate">The start date of the campaign.</param>
    /// <param name="endDate">The end date of the campaign.</param>
    /// <param name="budget">The budget allocated for the campaign.</param>
# FIXME: 处理边界情况
    public AdCampaign(string campaignName, DateTime startDate, DateTime endDate, int budget)
    {
        CampaignName = campaignName;
        StartDate = startDate;
# NOTE: 重要实现细节
        EndDate = endDate;
# 添加错误处理
        Budget = budget;
    }
}

/// <summary>
/// Manages ad campaigns within the Unity framework.
/// </summary>
public class AdCampaignManager
{
# 添加错误处理
    private List<AdCampaign> campaigns;

    /// <summary>
    /// Initializes a new instance of the AdCampaignManager class.
    /// </summary>
    public AdCampaignManager()
    {
        campaigns = new List<AdCampaign>();
    }

    /// <summary>
    /// Adds a new ad campaign to the system.
    /// </summary>
    /// <param name="campaign">The campaign to add.</param>
    /// <returns>True if the campaign was added successfully, false otherwise.</returns>
    public bool AddCampaign(AdCampaign campaign)
# 增强安全性
    {
        if (campaign == null)
        {
# NOTE: 重要实现细节
            Debug.LogError("Attempted to add a null campaign.");
            return false;
        }

        if (campaign.StartDate >= campaign.EndDate)
        {
            Debug.LogError("Campaign start date cannot be on or after the end date.");
            return false;
        }

        if (campaign.Budget <= 0)
        {
            Debug.LogError("Campaign budget must be greater than zero.");
            return false;
# TODO: 优化性能
        }

        // Add the campaign to the list.
        campaigns.Add(campaign);

        Debug.Log($"Campaign '{campaign.CampaignName}' added successfully.");
        return true;
    }

    /// <summary>
    /// Retrieves all active campaigns.
    /// </summary>
    /// <returns>A list of active campaigns.</returns>
    public List<AdCampaign> GetActiveCampaigns()
    {
        var activeCampaigns = new List<AdCampaign>();
        foreach (var campaign in campaigns)
        {
# 优化算法效率
            if (DateTime.Now >= campaign.StartDate && DateTime.Now <= campaign.EndDate)
# TODO: 优化性能
            {
                activeCampaigns.Add(campaign);
            }
        }
        return activeCampaigns;
    }
}
