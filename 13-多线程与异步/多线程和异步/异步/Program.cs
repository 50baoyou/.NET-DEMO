namespace 异步
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            /**
             * 异步->并行
             * 多线程->并发
             */
            // Task.Run方法是异步编程最常用的方法之一
            // 因其简洁性和易用性，它通常被用于启动一些长时间的后台操作或IO密集型操作

            //Calculate();

            await CalculatAsync();

            Console.WriteLine("结束");
        }

        // 问题：未等待异步操作结束
        //static void Calculate()
        //{
        //    // Task -> 异步
        //    // Thread -> 线程
        //    var task1 = Task.Run(() =>
        //    {
        //        return Calculate1();
        //    });
        //    var awaiter1 = task1.GetAwaiter();
        //    awaiter1.OnCompleted(() =>
        //    {
        //        var result1 = awaiter1.GetResult();
        //        var task2 = Task.Run(() =>
        //        {
        //            return Calculate2(result1);
        //        });

        //        var awaiter2 = task2.GetAwaiter();
        //        awaiter2.OnCompleted(() =>
        //        {
        //            var result2 = awaiter2.GetResult();
        //            var result = Calculate3(result1, result2);
        //            Console.WriteLine(result);
        //        });
        //    });
        //}

        // 使用 async和await 改造
        static async Task CalculatAsync()
        {
            var result1 = await Calculate1Async();
            var result2 = await Calculate2Async(result1);
            var result3 = await Calculate3Async(result1, result2);

            Console.WriteLine($"Calculate执行完毕：{result3}");
        }

        static async Task<int> Calculate1Async()
        {
            int result = 2;
            Console.WriteLine($"Calculate1: {result}");
            await Task.Delay(3000);

            return result;
        }

        static async Task<int> Calculate2Async(int a)
        {
            int result = a * 2;
            Console.WriteLine($"Calculate2: {result}");
            await Task.Delay(2000);

            return result;
        }

        static async Task<int> Calculate3Async(int a, int b)
        {
            int result = a + b;
            Console.WriteLine($"Calculate3: {result}");
            await Task.Delay(1000);

            return result;
        }
    }
}
