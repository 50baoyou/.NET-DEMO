using System;

namespace OOP
{
    internal class UIBase
    {
        public int Size { get; set; }
        public int Postion { get; set; }

        public void Draw()
        {
            Console.WriteLine("绘制UI");
        }
    }
}
