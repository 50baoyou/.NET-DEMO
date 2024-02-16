using System;

namespace TestLibrary
{
    // 在另一个项目中使用时，类需要添加访问修饰符
    // 类的默认访问修饰符为 internal，仅可在同一个程序集中使用
    public class A
    {
        protected int x = 123;
    }

    public class B : A
    {
        public void Todo()
        {
            // 受保护成员访问限于包含类或派生自包含类的类型。
            Console.WriteLine(this.x);
        }
    }

    public class Staff
    {
        public int Num { get; set; }

        public Staff()
        {
            Console.WriteLine("员工类初始化");
        }

        public Staff(int num)
        {
            Num = num;
            Console.WriteLine($"{num}员工类初始化");
        }
    }

    public class Manager : Staff
    {
        public Manager()
        {
            Console.WriteLine("经理类初始化");
        }

        public Manager(int num) : base(num)
        {
            Console.WriteLine($"{num}经理类初始化");
        }
    }

    public class Shape
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public Shape()
        {
            Console.WriteLine("形状类初始化");
        }

        public void Draw()
        {
            Console.WriteLine($"width: {Width}, height: {Height}, position {X}, {Y}");
        }
    }

    public class Font : Shape
    {
        public int FontSize { get; set; }
        public string FontName { get; set; }
    }

}
