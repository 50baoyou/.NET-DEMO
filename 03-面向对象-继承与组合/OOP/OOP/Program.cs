using System;
using System.Collections.Generic;
using TestLibrary;

namespace OOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //B b = new();
            //b.Todo();

            //Logger logger = new();
            //DbMigrator dbMigrator = new(logger);
            //Install install = new(logger);

            //install.StartInstall();

            //dbMigrator.StartMigrator();

            //Manager m = new(443);
            //Console.WriteLine(m.Num);

            Font font = new();
            Shape shape = font;

            List<Shape> shapeList = new();
            //shapeList.Add("addd");
            //shapeList.Add(123);
            shapeList.Add(shape);
            shapeList.Add(font);

            // 向下转型
            var shape1 = shapeList[1];
            if (shape1 is Font)
            {
                Font font1 = (Font)shape1;
            }

            // 装箱拆箱影响性能，使用List<>代替

            Console.WriteLine("Hello World!");
        }
    }
}
