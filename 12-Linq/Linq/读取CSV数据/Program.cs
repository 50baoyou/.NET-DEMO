namespace 读取CSV数据
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var cars = ProcessCars("./fuel.csv");
            // 按油耗排序
            //var query1 = cars
            //    .OrderBy(item => item.Combined) // 一级排序
            //    .ThenBy(item => item.Model); // 二级排序：在相同值的基础元素上应用另一个排序
            var query1 = (from car in cars
                          where car.Manufacturer == "BMW" && car.Year == "2016"
                          orderby car.Combined descending, car.Model descending
                          select new
                          {
                              // 数据投影
                              Model = car.Model,
                              Combined = car.Combined,
                          }).FirstOrDefault();

            //Console.WriteLine("1: " + query1.FirstOrDefault());

            //foreach (var item in query1.Take(10))
            //{
            Console.WriteLine($"{query1?.Model}--{query1?.Combined}");
            //}

            // any 查询是否存在一个元素满足条件
            var query2 = cars.Any(item => item.Manufacturer == "Volkswagen");
            if (query2)
            {
                Console.WriteLine("有大众");
            }
            else
            {
                Console.WriteLine("没有大众");
            }

            // contains 判断集合中是否包含特定元素
            //var query3 = cars.Contains(query1.FirstOrDefault());

            // all 检查集合中所有元素是否满足特定条件

            // SelectMany 将集合的集合（例如列表的列表）合并为单个集合时
            //var query4 = cars.SelectMany(item => item.Model);
        }

        private static List<Car> ProcessCars(string path)
        {
            // 读取文件
            var result = File.ReadAllLines(path)
                .Skip(1)
                .Where(item => item.Length > 1)
                .ToCar();
            //.Select(line =>
            //{
            //    var columns = line.Split(",");
            //    return new Car
            //    {
            //        Year = columns[0],
            //        Manufacturer = columns[1],
            //        Model = columns[2],
            //        Displacement = double.Parse(columns[3]),
            //        CylindersCount = int.Parse(columns[4]),
            //        City = int.Parse(columns[5]),
            //        Highway = int.Parse(columns[6]),
            //        Combined = int.Parse(columns[7]),
            //    };
            //}); 数据投影
            return result.ToList();
        }
    }

    // 扩展方法必须定义在静态类中
    internal static class CarExtensions
    {
        // 扩展方法
        // this 关键字在扩展方法（extension method）定义中被用于指明一个方法是作为哪种类型的扩展
        // 扩展方法的第一个参数指定方法扩展的类型，并且这个参数前面必须加上 this 关键字

        // 它扩展了 IEnumerable<string> 类型，
        // 使得任何 IEnumerable<string> 的实例（即一系列字符串）都可以调用 ToCar 方法
        public static IEnumerable<Car> ToCar(this IEnumerable<string> source)
        {
            foreach (var line in source)
            {
                var columns = line.Split(",");
                yield return new Car
                {
                    Year = columns[0],
                    Manufacturer = columns[1],
                    Model = columns[2],
                    Displacement = double.Parse(columns[3]),
                    CylindersCount = int.Parse(columns[4]),
                    City = int.Parse(columns[5]),
                    Highway = int.Parse(columns[6]),
                    Combined = int.Parse(columns[7]),
                };
            }
        }
    }
}
