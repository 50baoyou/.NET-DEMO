using System;

namespace HelloWorld
{
    struct Game
    {
        public string name;
        public string developer;
        public DateTime releaseDate;

        public void GetInfo()
        {
            Console.WriteLine("游戏名称：" + name);
            Console.WriteLine("开发人员：" + developer);
            Console.WriteLine("发行日期：" + releaseDate);
        }
    }

    enum Weekday
    {
        MONDAY,
        TUESDAY,
        WEDNESDAY,
        THURSDAY,
        FRIDAY,
        SATURDAY,
        SUNDAY,
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // 值类型，与 Class 类似（引用类型，保存在堆内存），但在栈中分配内存（栈内存运行效率高）
            // 坐标 形状 颜色 推荐使用结构体
            Game game;
            game.name = "347";
            game.developer = "xk";
            game.releaseDate = DateTime.Today;

            game.GetInfo();

            var numberList = new GenericList<int>();
            var productList = new GenericList<Product>();

            // 空处理，可空类型：Nullable
            //  Nullable<T> 类型在没有值时会被视为"未初始化"，而不是具有一个值为 null
            // Nullable<DateTime> date = null
            Nullable<DateTime> date = new Nullable<DateTime>();
            // 简写：？
            DateTime? date1 = null;
            Console.WriteLine("date: " + date);
            Console.WriteLine(date.GetValueOrDefault());
            Console.WriteLine(date.HasValue);
            Console.WriteLine("date1: " + date1);
            Console.WriteLine(date1.GetValueOrDefault());
            Console.WriteLine(date1.HasValue);

            // Null 合并操作符：??
            // 如果左操作数的值不为 null，则 null 合并运算符 ?? 返回该值；否则，它会计算右操作数并返回其结果。
            var result = date1 ?? DateTime.Now;
            Console.WriteLine(result);

            // 使用静态方法进行扩展
            string str = "abcdef";
            Console.WriteLine(str.ShortTerm(3));

            dynamic type = new Product();
            type = "动态类型，在执行时才能确定类型";

            // 反射
            string classLocation = "HelloWorld.List, HelloWorld";
            var objType = Type.GetType(classLocation);
            var obj = Activator.CreateInstance(objType);

            var method = objType.GetMethod("Add");
            method.Invoke(obj, new object[] { 123 });

            string[] strings = new string[] { "1", "2", "3" };
        }
    }
}
