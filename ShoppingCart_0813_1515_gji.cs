// 代码生成时间: 2025-08-13 15:15:16
using System;
# 扩展功能模块
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Represents a shopping cart item.
/// </summary>
public class ShoppingCartItem
{
    public string ItemId { get; set; }
    public string ItemName { get; set; }
    public float Price { get; set; }
    public int Quantity { get; set; }
# FIXME: 处理边界情况

    public ShoppingCartItem(string itemId, string itemName, float price, int quantity)
    {
        ItemId = itemId;
        ItemName = itemName;
        Price = price;
# FIXME: 处理边界情况
        Quantity = quantity;
    }
}

/// <summary>
/// Manages the shopping cart functionality.
# 添加错误处理
/// </summary>
public class ShoppingCart
{
    private List<ShoppingCartItem> items;

    public ShoppingCart()
    {
        items = new List<ShoppingCartItem>();
    }

    /// <summary>
    /// Adds an item to the shopping cart.
    /// </summary>
    /// <param name="item">The item to be added.</param>
    public void AddItem(ShoppingCartItem item)
    {
        if (item == null)
            throw new ArgumentNullException(nameof(item), "Item cannot be null.");

        var existingItem = items.Find(x => x.ItemId == item.ItemId);
        if (existingItem != null)
        {
            existingItem.Quantity += item.Quantity;
        }
        else
        {
            items.Add(item);
        }
    }

    /// <summary>
# NOTE: 重要实现细节
    /// Removes an item from the shopping cart.
    /// </summary>
    /// <param name="itemId">The ID of the item to be removed.</param>
    public void RemoveItem(string itemId)
    {
        var item = items.Find(x => x.ItemId == itemId);
        if (item != null)
        {
            items.Remove(item);
        }
        else
        {
            Debug.LogError("Item not found in the shopping cart.");
        }
    }

    /// <summary>
    /// Updates the quantity of an existing item in the shopping cart.
    /// </summary>
    /// <param name="itemId">The ID of the item to be updated.</param>
    /// <param name="quantity">The new quantity of the item.</param>
    public void UpdateItemQuantity(string itemId, int quantity)
# 添加错误处理
    {
# NOTE: 重要实现细节
        var item = items.Find(x => x.ItemId == itemId);
        if (item != null)
        {
            if (quantity <= 0)
            {
                RemoveItem(itemId);
# 添加错误处理
            }
            else
            {
                item.Quantity = quantity;
            }
        }
        else
# NOTE: 重要实现细节
        {
            Debug.LogError("Item not found in the shopping cart.");
        }
    }

    /// <summary>
    /// Clears the shopping cart.
    /// </summary>
    public void ClearCart()
    {
        items.Clear();
    }

    /// <summary>
    /// Calculates the total price of the items in the cart.
    /// </summary>
    /// <returns>The total price.</returns>
    public float CalculateTotal()
    {
        float total = 0;
        foreach (var item in items)
        {
            total += item.Price * item.Quantity;
        }
        return total;
    }

    /// <summary>
    /// Returns a list of all items in the cart.
    /// </summary>
    /// <returns>A list of shopping cart items.</returns>
# NOTE: 重要实现细节
    public List<ShoppingCartItem> GetAllItems()
    {
        return items;
    }
}
