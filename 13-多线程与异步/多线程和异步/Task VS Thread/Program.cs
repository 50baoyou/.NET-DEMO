using System.Diagnostics;

namespace Task_VS_Thread
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 异步不是多线程
            // 异步 -》 并行
            // 多线程 -》 并发

            // Task 效率更高，但是会占用更多内存
            TaskTest();
            ThreadTest();
            Console.WriteLine("Hello, World!");
        }

        // 异步 -- 类似回调
        // Task 是在ThreadPool的基础上进行的封装
        // Task可以简单看作相当于Thead+TheadPool，
        // 其性能比直接使用Thread要更好，在工作中更多的是使用Task来处理多线程任务
        static void TaskTest()
        {
            // 计时器
            Stopwatch sw = new();
            sw.Start();

            for (int i = 0; i < 100; i++)
            {
                // 创建异步任务
                Task.Factory.StartNew(() => { });
            }

            sw.Stop();
            Console.WriteLine($"Task: {sw.ElapsedMilliseconds}");
        }

        static void ThreadTest()
        {
            // 计时器
            Stopwatch sw = new();
            sw.Start();

            for (int i = 0; i < 100; i++)
            {
                // 创建线程
                new Thread(() => { }).Start();
            }

            sw.Stop();
            Console.WriteLine($"Thread: {sw.ElapsedMilliseconds}");
        }
    }
}
