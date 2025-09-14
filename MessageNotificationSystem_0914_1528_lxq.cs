// 代码生成时间: 2025-09-14 15:28:32
using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Message Notification System
/// This class handles message notifications in a Unity application.
/// </summary>
public class MessageNotificationSystem : MonoBehaviour
{
    private static MessageNotificationSystem instance;
    private List<Message> messageQueue;

    /// <summary>
    /// Gets the singleton instance of the notification system.
    /// </summary>
    public static MessageNotificationSystem Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<MessageNotificationSystem>();
                if (instance == null)
                {
                    GameObject notificationManager = new GameObject("MessageNotificationSystem");
                    instance = notificationManager.AddComponent<MessageNotificationSystem>();
                }
                instance.messageQueue = new List<Message>();
            }
            return instance;
        }
    }

    /// <summary>
    /// Adds a message to the notification queue.
    /// </summary>
    /// <param name="message">The message to be added.</param>
    public void EnqueueMessage(Message message)
    {
        if (message == null)
        {
            Debug.LogError("Attempted to enqueue a null message.");
            return;
        }

        messageQueue.Add(message);
        SendMessageToSubscribers();
    }

    /// <summary>
    /// Sends messages to subscribers.
    /// </summary>
    private void SendMessageToSubscribers()
    {
        while (messageQueue.Count > 0)
        {
            Message message = messageQueue[0];
            foreach (var subscriber in message.Subscribers)
            {
                subscriber.ReceiveMessage(message);
            }
            messageQueue.RemoveAt(0);
        }
    }

    /// <summary>
    /// A basic message class containing the message text and subscribers.
    /// </summary>
    public class Message
    {
        public string Text;
        public List<IMessageSubscriber> Subscribers;

        public Message(string text)
        {
            Text = text;
            Subscribers = new List<IMessageSubscriber>();
        }
    }

    /// <summary>
    /// Interface for message subscribers.
    /// </summary>
    public interface IMessageSubscriber
    {
        void ReceiveMessage(Message message);
    }
}
