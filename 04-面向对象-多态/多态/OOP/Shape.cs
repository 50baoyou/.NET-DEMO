using System;

namespace OOP
{
    // 多态：同一个行为具有多个不同表现形式或形态的能力
    internal abstract class Shape
    {
        public int Width { get; set; }
        public int Height { get; set; }
        // 声明抽象属性时，只需指明哪些属性访问器可用即可，不要实现它们。
        //public abstract double Area { get; }
        //public Position Position { get; set; }
        //public ShapeType ShapeType { get; set; }

        // 虚方法，在派生类中不强制重写
        // 抽象方法，只声明，不定义，由派生类自由实现
        public abstract void Draw();
    }

    internal class Circle : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("绘制圆形");
        }
    }

    internal class Rectangle : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("绘制矩形");
        }
    }

    internal class Oval : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("绘制椭圆形");
        }
    }
}
