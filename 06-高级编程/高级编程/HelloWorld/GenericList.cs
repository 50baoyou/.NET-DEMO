using System;

namespace HelloWorld
{
    internal class GenericList<T>
    {
        public void Add(T item)
        {
            throw new NotImplementedException();
        }

        public T this[int index]
        {
            get { throw new NotImplementedException(); }
        }
    }
}
