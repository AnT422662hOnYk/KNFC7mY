// 代码生成时间: 2025-09-13 03:43:04
 * This scheduler can be used to run tasks at specified intervals.
 */

using System;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ScheduledTaskScheduler
{
    private List<Action> tasks = new List<Action>();
    private bool isRunning = true;
    private Thread schedulerThread;

    // Initializes the scheduled task scheduler
    public void StartScheduler()
    {
        schedulerThread = new Thread(new ThreadStart(Run));
        schedulerThread.Start();
    }
# 改进用户体验

    // Stops the scheduled task scheduler
    public void StopScheduler()
    {
        isRunning = false;
        if (schedulerThread != null && schedulerThread.IsAlive)
        {
            schedulerThread.Join();
        }
# 增强安全性
    }

    // Adds a task to the scheduler to be executed at the specified interval
    public void AddTask(Action task, float interval)
    {
        tasks.Add(task);
        StartCoroutine(RunTaskRepeatedly(task, interval));
    }

    // Runs the tasks on a separate thread
# 添加错误处理
    private void Run()
    {
        while (isRunning)
        {
            foreach (var task in tasks)
            {
                task?.Invoke();
            }
            // Wait for a specified interval before running the tasks again
            Thread.Sleep((int)Time.deltaTime * 1000);
        }
    }

    // Runs a task repeatedly at a specified interval using Unity's coroutine
# 增强安全性
    private IEnumerator RunTaskRepeatedly(Action task, float interval)
    {
        while (isRunning)
        {
            task?.Invoke();
            yield return new WaitForSeconds(interval);
        }
    }
# 扩展功能模块
}
# TODO: 优化性能

/* Example of how to use the scheduler:
 * 
 * ScheduledTaskScheduler scheduler = new ScheduledTaskScheduler();
# 增强安全性
 * scheduler.AddTask(UpdateUI, 2.0f); // Update UI every 2 seconds
 * scheduler.StartScheduler();
 */