// 代码生成时间: 2025-09-07 04:27:58
 * This class allows scheduling tasks to be executed at specific times or intervals.
 */
using System;
using System.Collections.Generic;
using UnityEngine;

public class ScheduledTaskManager
{
    private Dictionary<DateTime, Action> scheduledTasks;
    private DateTime lastExecutionTime;
    private bool isRunning;

    public ScheduledTaskManager()
    {
        scheduledTasks = new Dictionary<DateTime, Action>();
        lastExecutionTime = DateTime.MinValue;
        isRunning = false;
    }

    /**
     * Schedules a task to be executed at a specific time.
     * @param time The time at which the task should be executed.
     * @param action The task to be executed.
     */
    public void ScheduleTask(DateTime time, Action action)
    {
        if (!scheduledTasks.ContainsKey(time))
        {
            scheduledTasks.Add(time, action);
        }
        else
        {
            Debug.LogError("Task already scheduled for this time: " + time);
        }
    }

    /**
     * Schedules a recurring task to be executed at a specific interval.
     * @param interval The interval at which the task should be executed.
     * @param action The task to be executed.
     */
    public void ScheduleRecurringTask(TimeSpan interval, Action action)
    {
        // This method implementation is not provided in this sample
        throw new NotImplementedException("You need to implement the recurring task scheduling logic.");
    }

    /**
     * Starts the task manager, which checks for scheduled tasks to execute.
     */
    public void Start()
    {
        if (!isRunning)
        {
            isRunning = true;
            // Unity's Update method will call CheckAndExecuteTasks
            lastExecutionTime = DateTime.Now;
        }
        else
        {
            Debug.LogWarning("The task manager is already running.");
        }
    }

    /**
     * Stops the task manager from executing tasks.
     */
    public void Stop()
    {
        isRunning = false;
    }

    /**
     * Checks for tasks that are due to be executed and executes them.
     */
    private void CheckAndExecuteTasks()
    {
        if (isRunning)
        {
            foreach (var task in scheduledTasks)
            {
                if (DateTime.Now >= task.Key)
                {
                    task.Value.Invoke();
                    scheduledTasks.Remove(task.Key);
                }
            }
        }
    }

    // Unity's Update method will be called once per frame.
    private void Update()
    {
        // This method will call CheckAndExecuteTasks to check for tasks to execute.
        CheckAndExecuteTasks();
    }
}
