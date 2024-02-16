namespace 资源竞争与线程锁
{
    internal class Program
    {
        // 线程锁
        // 创建一个静态的，只读的，并且是唯一的对象锁，对所有类的实例进行同步，提供线程安全的保护
        static readonly object balanceLock = new();
        static void Main(string[] args)
        {
            // 创建一个线程列表以保存所有的线程
            List<Thread> threads = new();

            // 创建和启动线程
            for (int i = 0; i < 10; i++)
            {
                Thread thread = new(AddText);
                thread.Start();

                // 把线程添加到列表而不是等待它完成
                threads.Add(thread);
            }

            // 在所有线程都启动之后，遍历线程列表等待它们全部完成
            foreach (Thread thread in threads)
            {
                thread.Join();
            }

            string result = File.ReadAllText("./temp.txt");
            Console.WriteLine(result);
        }

        static void AddText()
        {
            /**
             * lock 语句获取给定对象的互斥 lock，执行语句块，然后释放 lock。
             * 持有 lock 时，持有 lock 的线程可以再次获取并释放 lock。
             * 阻止任何其他线程获取 lock 并等待释放 lock
             */
            lock (balanceLock)
            {
                String path = "./temp.txt";

                // 打开一个文件，将字符串追加到末尾
                File.AppendAllText(path, $"开始 {Environment.CurrentManagedThreadId}");
                Thread.Sleep(1000);
                File.AppendAllText(path, $"结束 {Environment.CurrentManagedThreadId}");
            }
        }
    }
}
