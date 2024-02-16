namespace IEnumerable接口和IEnumerator接口
{
    internal class Program
    {
        static IEnumerable<Customer> GetCustomers(int count)
        {
            for (int i = 0; i < count; i++)
            {
                yield return new Customer(i, $"老默{i}", "长沙");
            }
        }

        static IEnumerable<Customer> GetCustomersYield(int count)
        {
            var customers = new List<Customer>();

            for (int i = 0; i < count; i++)
            {
                customers.Add(new Customer(i, $"老默{i}", "长沙"));
            }

            return customers;
        }

        static IEnumerable<int> CreateEnumerable()
        {
            yield return 1;
            yield return 2;
            yield return 3;
        }

        static Dictionary<int, Customer> GetCustomersDictionary(int count)
        {
            var customers = new Dictionary<int, Customer>();

            for (int i = 0; i < count; i++)
            {
                customers.Add(i, new Customer(i, $"老默{i}", "长沙"));
            }

            return customers;
        }

        static void Main(string[] args)
        {
            /**
             * IEnumerable<T> 这是一个可以枚举的泛型集合的接口
             * 任何实现了 IEnumerable<T> 的类或结构都含有一个返回 IEnumerator<T> 的 GetEnumerator() 方法
             * 它表示一个可遍历的序列，但本身不负责遍历
             */

            /**
             * IEnumerator<T> 这是泛型迭代器的接口，用于遍历 IEnumerable<T>
             * 迭代器提供了 Current 属性来访问集合中的当前元素，并且有一个 MoveNext() 方法用于移至序列中的下一个元素
             * 一旦迭代完成或者 IEnumerator<T> 被释放，需要调用 Dispose() 方法来释放迭代器所持有的资源
             */

            // 总结来说
            // IEnumerable<T> 提供了一个获取迭代器的机制
            // 而 IEnumerator<T> 是具体实施迭代过程的工具

            var bank = new Bank();

            foreach (var item in bank)
            {
                Console.WriteLine(item.Name);
            }

            //var customers = GetCustomers(1000);

            //foreach (var item in customers)
            //{
            //    if (item.Id < 10)
            //    {
            //        Console.WriteLine(item.ToString());
            //    }
            //    else
            //    {
            //        break;
            //    }
            //}

            /**
             * Yield 用来在迭代器块中一次返回一个值，同时保持当前在代码中的位置
             * 这个过程是懒加载的，值是在需要的时候才生成的
             * yield 通常用于自定义集合类的迭代器方法中
             * 
             * 使用 yield return 语句可以返回一个值，
             * 并保留当前在迭代器方法中的状态，下一次调用迭代器方法时，将从上次返回的位置继续执行
             */
            var customers = GetCustomersYield(1000);
            foreach (var item in customers)
            {
                if (item.Id < 10)
                {
                    Console.WriteLine(item.ToString());
                }
                else
                {
                    break;
                }
            }

            foreach (var item in CreateEnumerable())
            {
                Console.WriteLine(item);
            }

            // 字典
            var customersD = GetCustomersDictionary(1000);
            var customer = customersD.GetValueOrDefault(999);

            Console.WriteLine(customer);

            // 哈希表 hashtable 几乎和字典相同
        }
    }
}
