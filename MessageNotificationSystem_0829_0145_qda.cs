// 代码生成时间: 2025-08-29 01:45:20
using System;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

/// <summary>
/// 消息通知系统，负责发送和接收消息通知。
/// </summary>
public class MessageNotificationSystem : MonoBehaviour
{
    private List<MessageObserver> observers = new List<MessageObserver>();

    void Start()
    {
        // 在Unity的Start方法中初始化系统
        Initialize();
    }

    /// <summary>
    /// 初始化消息通知系统
    /// </summary>
    private void Initialize()
    {
        // 这里可以添加初始化逻辑
    }

    /// <summary>
    /// 注册一个观察者，以便它可以接收消息通知
    /// </summary>
    /// <param name="observer">观察者的实例</param>
    public void RegisterObserver(MessageObserver observer)
    {
        if (observer == null)
        {
            Debug.LogError("Observer cannot be null.");
            return;
        }

        if (!observers.Contains(observer))
        {
            observers.Add(observer);
        }
    }

    /// <summary>
    /// 注销一个观察者，使它不再接收消息通知
    /// </summary>
    /// <param name="observer">观察者的实例</param>
    public void UnregisterObserver(MessageObserver observer)
    {
        if (observer != null)
        {
            observers.Remove(observer);
        }
    }

    /// <summary>
    /// 发送消息通知给所有注册的观察者
    /// </summary>
    /// <param name="message">需要发送的消息</param>
    public void NotifyObservers(string message)
    {
        foreach (var observer in observers)
        {
            observer.ReceiveMessage(message);
        }
    }
}

/// <summary>
/// 观察者接口，定义接收消息的方法
/// </summary>
public interface MessageObserver
{
    void ReceiveMessage(string message);
}

/// <summary>
/// 示例观察者实现，用于接收消息通知
/// </summary>
public class ExampleObserver : MonoBehaviour, MessageObserver
{
    private MessageNotificationSystem notificationSystem;

    void Start()
    {
        // 在Unity的Start方法中获取消息通知系统实例并注册当前观察者
        notificationSystem = FindObjectOfType<MessageNotificationSystem>();
        if (notificationSystem != null)
        {
            notificationSystem.RegisterObserver(this);
        }
        else
        {
            Debug.LogError("MessageNotificationSystem instance not found in the scene.");
        }
    }

    void OnDestroy()
    {
        // 在Unity的OnDestroy方法中注销当前观察者
        if (notificationSystem != null)
        {
            notificationSystem.UnregisterObserver(this);
        }
    }

    /// <summary>
    /// 实现接收消息的方法
    /// </summary>
    /// <param name="message">接收到的消息</param>
    public void ReceiveMessage(string message)
    {
        Debug.Log($"Received message: {message}");
    }
}