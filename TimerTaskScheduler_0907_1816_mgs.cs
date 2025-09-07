// 代码生成时间: 2025-09-07 18:16:01
 * This class is a simple timer task scheduler that allows scheduling tasks to run at specified intervals.
 * It is designed to be easy to understand, maintain, and extend, while following C# best practices.
 */
using System;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class TimerTaskScheduler
{
    // A dictionary to hold scheduled tasks with their next execution time
    private Dictionary<IDisposable, DateTime> scheduledTasks = new Dictionary<IDisposable, DateTime>();

    // Starts a new timer task that executes the given action repeatedly at the specified interval
    public IDisposable Schedule(TimerCallback action, TimeSpan interval)
    {
        if (action == null) throw new ArgumentNullException(nameof(action));
        if (interval <= TimeSpan.Zero) throw new ArgumentException("Interval must be greater than zero.", nameof(interval));

        var timer = new Timer(TimerCallback, null, (long)interval.TotalMilliseconds, (long)interval.TotalMilliseconds);
        scheduledTasks.Add(timer, DateTime.UtcNow);
        return timer;
    }

    // Executes the action passed to the Schedule method
    private void TimerCallback(object state)
    {
        // Loop through all scheduled tasks and execute those whose next execution time has come
        foreach (var task in scheduledTasks.Keys)
        {
            var timer = (Timer)task;
            var dueTime = scheduledTasks[timer];
            if (DateTime.UtcNow >= dueTime)
            {
                timer.Change(Timeout.Infinite, Timeout.Infinite); // Disable the timer temporarily
                TimerCallback callback = (TimerCallback)timer.Tag;
                callback(timer);
            }
        }
    }

    // Stops a previously scheduled task
    public void Unschedule(IDisposable task)
    {
        if (task == null) throw new ArgumentNullException(nameof(task));

        if (scheduledTasks.ContainsKey(task))
        {
            var timer = (Timer)task;
            timer.Change(Timeout.Infinite, Timeout.Infinite); // Stop the timer
            scheduledTasks.Remove(task);
        }
    }

    // Clears all scheduled tasks
    public void ClearAllScheduledTasks()
    {
        foreach (var task in scheduledTasks.Keys)
        {
            var timer = (Timer)task;
            timer.Change(Timeout.Infinite, Timeout.Infinite); // Stop the timer
        }
        scheduledTasks.Clear();
    }

    // Disposes of all resources used by the scheduler
    public void Dispose()
    {
        foreach (var task in scheduledTasks.Keys)
        {
            var timer = (Timer)task;
            timer.Dispose();
        }
        scheduledTasks.Clear();
    }
}

// Extension method to simplify the scheduling of tasks
public static class TimerTaskSchedulerExtensions
{
    public static IDisposable Schedule(this TimerTaskScheduler scheduler, Action action, TimeSpan interval)
    {
        return scheduler.Schedule(timer => action(), interval);
    }
}
