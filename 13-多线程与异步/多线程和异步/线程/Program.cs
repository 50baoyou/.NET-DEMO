namespace 线程
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 创建新线程
            //Thread thread = new(() =>
            //{
            //    PrintDemo();
            //});
            //thread.Start();

            //for (int i = 0; i < 1000; i++)
            //{
            //    Console.Write(0);
            //    // 休眠1s  Thread.Sleep(1000); 
            //}

            // 前台线程，后台线程
            //Thread thread = new(PrintDemo)
            //{
            //    IsBackground = true // 切换为后台线程
            //};
            //thread.Start();

            // 线程池
            //for (int i = 0; i < 100; i++)
            //{
            //手动创建线程
            //Thread thread = new(() =>
            //{
            //    Console.WriteLine($"循环次数 {i}，线程ID：{Thread.CurrentThread.ManagedThreadId}");
            //});
            //thread.Start();

            // 使用线程池
            //ThreadPool.QueueUserWorkItem((obj) =>
            //{
            //    // 当前托管线程的唯一标识符
            //    Console.WriteLine($"线程ID：{Environment.CurrentManagedThreadId}");
            //});
            //}

            // 结束线程 
            // 创建令牌，于取消运行中的任务或操作
            CancellationTokenSource tokenSource = new();

            Thread thread = new(() => { PrintDemo(tokenSource.Token); });
            thread.Start();

            // 其他操作
            Thread.Sleep(3000);

            //关闭子线程
            tokenSource.Cancel();
            // tokenSource.CancelAfter(3000); 3s后失效

            // 等待子线程完成，主线程才继续执行
            thread.Join();

            // IsAlive 检查线程是否还在执行

            Console.WriteLine("结束");
        }

        static void PrintDemo(CancellationToken token)
        {
            // 检查令牌是否取消
            while (!token.IsCancellationRequested)
            {
                Console.Write(1);
                Thread.Sleep(1000);
            }
        }
    }
}
