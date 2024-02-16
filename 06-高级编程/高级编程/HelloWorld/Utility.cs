using System;

namespace HelloWorld
{
    internal class Utility<T> where T : IComparable, new()
    {
        public void DoSome()
        {
            var obj = new T();
        }

        public int FindMax(int a, int b)
        {
            return a > b ? a : b;
        }

        public T FindMax(T a, T b)
        {
            return a.CompareTo(b) > 0 ? a : b;
        }
    }
}
