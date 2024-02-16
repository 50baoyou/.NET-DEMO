namespace 垃圾回收GC
{
    internal class Program
    {
        public class Demo
        {
            public Demo()
            {
                Console.WriteLine("Demo 类创建");
            }

            // 终结器不能手动调用，只能由垃圾回收器调用
            ~Demo()
            {
                Console.WriteLine("Demo 类销毁");
            }
        }
        static void DoSome()
        {
            Demo demo = new();
        }
        static void Main(string[] args)
        {
            /**
             * 内存
             * 
             * Stack 栈内存
             * 1.速度快，效率高
             * 2.类型，大小有限制
             * 3.只能保存简单的数据
             * 4.基础数据类型，值类型
             * 
             * Heap 堆内存
             * 1.结构复杂的数据
             * 2.对象
             * 3.引用类型数据
             */

            DoSome();
            GC.WaitForPendingFinalizers();
            GC.Collect();

            Console.WriteLine("Hello, World!");
        }
    }
}
