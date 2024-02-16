using System.Collections.Generic;

namespace OOP
{
    internal class Canvas
    {
        public void DrawShapes(List<Shape> shapes)
        {
            foreach (var item in shapes)
            {
                //switch (item.ShapeType)
                //{
                //    case ShapeType.Circle:
                //        Console.WriteLine("绘制圆形")；
                //            break;
                //    case ShapeType.Rectangle:
                //        Console.WriteLine("绘制矩形")；
                //            break;
                //}
                item.Draw();
            }
        }
    }
}
