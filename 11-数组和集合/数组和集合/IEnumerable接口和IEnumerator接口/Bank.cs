using System.Collections;

namespace IEnumerable接口和IEnumerator接口
{
    internal class Bank : IEnumerable<Customer>
    {
        public MyList<Customer> Customers { get; set; }

        public Bank()
        {
            Customers = new MyList<Customer>(4)
            {
                new(1,"XK","上海"),
                new(2,"老莫","广州"),
                new(3,"白给","长沙"),
                new(4,"葡萄糖","福建")
            };
        }

        public IEnumerator<Customer> GetEnumerator()
        {
            return Customers.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
