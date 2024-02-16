using System.Collections;

namespace IEnumerable接口和IEnumerator接口
{
    internal class MyEnumerator<T> : IEnumerator<T>
    {
        private T[] _data;
        private int _index;

        public MyEnumerator(T[] data)
        {
            _data = data;
            _index = -1;
        }

        public T Current
        {
            get => _data[_index]; // Lambda 表达式
        }

        object IEnumerator.Current => throw new NotImplementedException();

        public void Dispose()
        {
            Console.WriteLine("释放迭代器所持有的资源");
        }

        public bool MoveNext()
        {
            _index++;
            return _index < _data.Length;
        }

        public void Reset()
        {
            _index = -1;
        }
    }
}
