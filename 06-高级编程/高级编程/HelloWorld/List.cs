using System;

namespace HelloWorld
{
    internal class List
    {
        public void Add(int number)
        {
            //throw new NotImplementedException();
            Console.WriteLine("Add: " + number);
        }

        public int this[int index]
        {
            // get 读取访问器
            get { throw new NotImplementedException(); }
        }
    }
}
