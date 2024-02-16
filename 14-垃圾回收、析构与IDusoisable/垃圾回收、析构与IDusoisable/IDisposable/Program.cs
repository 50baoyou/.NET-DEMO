namespace 使用IDisposable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 使用 Disposable 处理非托管资源
            // 如：数据库连接，文件读取，HEEP长连接
            for (int i = 0; i < 1000; i++)
            {
                using DBHelper db = new();
                var date = db.GetData();
                Console.WriteLine($"[{DateTime.Now.ToLocalTime()}; {date}]");
            }

            Console.WriteLine("Hello, World!");
        }
    }
}
