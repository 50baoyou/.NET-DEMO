using System.Diagnostics.CodeAnalysis;

namespace Linq入门
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Customer> list = new()
            {
                new(1,"Alex","上海"),
                new(2,"Xk","深圳"),
                new(3,"Anna","江苏"),
                new(4,"Lshen","长沙"),
                new(5,"Lmo","广州"),
                new(6,"Bob","武汉"),
                new(7,"Tony","上海"),
                new(8,"Score","深圳"),
            };

            var query = from c in list
                        where c.Address == "上海"
                        orderby c.Name
                        select c;

            foreach (var item in query)
            {
                Console.WriteLine($"查询表达式语法：{item.Id}, {item.Name}, {item.Address}");
            }

            var result = list
                .Where(item => item.Address == "上海")
                //.MyWhere(item => item.Address == "上海") 自定义 MyWhere 语句
                .OrderBy(item => item.Name);

            foreach (var item in result)
            {
                Console.WriteLine($"方法链语法：{item.Id}, {item.Name}, {item.Address}");
            }
        }
    }

    class Student
    {
        [NotNull]
        public string Name { get; set; } = "Default Name";
        public int Score { get; set; } = 0;

        public Student() { }

        public Student(string name, int score)
        {
            // 非空检查
            ArgumentNullException.ThrowIfNull(name);
            Name = name;
            Score = score;
        }
    }
}
