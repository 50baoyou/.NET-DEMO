namespace List操作
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] week =
            {
                "星期一",
                "星期二",
                "星期三",
                "星期四",
                "星期五",
                "星期六",
                "星期天"
            };

            var daysOfWeek1 = new List<string>(week);

            // Capacity 容量
            Console.WriteLine($"{daysOfWeek1.Count}/{daysOfWeek1.Capacity}");

            var daysOfWeek2 = new List<String>
            {
                "星期一",
                "星期二",
                "星期三",
                "星期四",
                "星期五",
                "星期六",
                "星期天"
            };
            daysOfWeek2.Add("星期八"); // 添加单个元素
            daysOfWeek2.AddRange(week); // 添加集合
            daysOfWeek2.Insert(0, "尽量避免使用 Insert"); // 插入元素到指定位置
            daysOfWeek2.RemoveAt(0); // 删除制定位置的元素
            daysOfWeek2.Remove("星期八"); // 删除指定元素
            daysOfWeek2.RemoveAll(i => i.Contains("一")); // 删除包含字符串“一”的元素
            Console.WriteLine($"{daysOfWeek2.Count}/{daysOfWeek2.Capacity}");

            // string.join 将字符串数组或字符串集合的元素连接成一个单独的字符串
            // 并且可以使用指定的分隔符来分隔这些元素
            Console.WriteLine(string.Join(",", daysOfWeek2));

            // 索引器
            var index = daysOfWeek2[0];

            // 迭代器
            var enumerator = daysOfWeek2.GetEnumerator();

            // 遍历列表
            foreach (var item in daysOfWeek2)
            {
                Console.WriteLine(item);
            }
        }
    }
}
