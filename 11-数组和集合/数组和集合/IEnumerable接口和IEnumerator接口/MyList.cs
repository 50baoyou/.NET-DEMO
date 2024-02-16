using System.Collections;

namespace IEnumerable接口和IEnumerator接口
{
    internal class MyList<T> : IEnumerable<T>
    {
        private T[] _data;
        private int _index;

        public MyList(int length)
        {
            this._data = new T[length];
            _index = 0;
        }

        public void Add(T obj)
        {
            _data[_index] = obj;
            _index++;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new MyEnumerator<T>(_data);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
