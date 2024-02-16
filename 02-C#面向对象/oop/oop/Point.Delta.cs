using System;

namespace oop
{
    public partial class Point
    {
        //第九维 delta
        public int D { get; set; }

        public void printDelta()
        {
            Console.WriteLine("我是第九维");
        }
    }
}
