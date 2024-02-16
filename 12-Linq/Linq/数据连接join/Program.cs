namespace 数据连接join
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var cars = ProcessCars("./fuel.csv");
            var manufacturers = ProcessManufacturers("./manufacturers.csv");

            // join 连接 相当于sql语句的 inner join
            var query1 = (from car in cars
                          join manufacturer in manufacturers on car.Manufacturer equals manufacturer.Name
                          orderby car.Combined descending, car.Model descending
                          select new
                          {
                              Manufacturer = car.Manufacturer,
                              Model = car.Model,
                              Combiner = car.Combined,
                              Headquarters = manufacturer.Headquarters,
                              Phone = manufacturer.Phone
                          }).Take(10);

            var query2 = cars
                .Join(manufacturers, car => car.Manufacturer, manufacturer => manufacturer.Name, (car, manufacturer) => new
                {
                    Car = car,
                    Manufacturer = manufacturer,
                })
                .OrderByDescending(joinData => joinData.Car.Combined)
                .ThenByDescending(joinData => joinData.Car.Model)
                .Select(joinData => new
                {
                    Manufacturer = joinData.Car.Manufacturer,
                    Model = joinData.Car.Model,
                    Combiner = joinData.Car.Combined,
                    Headquarters = joinData.Manufacturer.Headquarters,
                    Phone = joinData.Manufacturer.Phone
                }).Take(10);

            // group 分组
            var query3 = from car in cars
                         group car by car.Manufacturer into manufacturerGroup
                         orderby manufacturerGroup.Key descending
                         select manufacturerGroup;

            var query4 = cars
                .GroupBy(c => c.Manufacturer)
                .OrderByDescending(g => g.Key);

            // group join
            var query5 = from manufacturer in manufacturers
                         join car in cars on manufacturer.Name equals car.Manufacturer
                         into carGroup // 提取分组信息
                         orderby manufacturer.Name descending
                         select new
                         {
                             Manufacturer = manufacturer,
                             Cars = carGroup
                         };

            var query6 = manufacturers
                .GroupJoin(cars, m => m.Name, c => c.Manufacturer, (m, c) => new
                {
                    Manufacturer = m,
                    Cars = c
                })
                .OrderByDescending(m => m.Manufacturer.Name);
            /**
             * into 用来保存一个临时分组或变量
             * 
             * group by ... into 用法：
             * 当使用group by进行分组操作之后，可以通过into关键字给这个分组的结果一个名称
             * 这使得你可以对分组后的结果（即分组集合）进行进一步的操作，比如筛选、排序或聚合
             * 
             * select ... into 用法：
             * select ... into可以在查询表达式中创建一个新的临时变量以进行查询结果的投影
             * 这不同于group by ... into，而是在查询的select阶段使用，以创建新的匿名类型或者新的数据结构来存储选择的数据
             */
            var query7 = from car in cars
                         group car by car.Manufacturer
                         into carGroup // 保存的是按照指定 Key 分组后的 car 集合
                         select new
                         {
                             Manufacturer = carGroup.Key,
                             Avg = carGroup.Average(c => c.Combined),
                             Max = carGroup.Max(c => c.Combined),
                             Min = carGroup.Min(c => c.Combined),
                         }
                         into tempGroup // 临时保存
                         orderby tempGroup.Avg descending
                         select tempGroup;

            foreach (var item in query7)
            {
                //Console.WriteLine($"{item.Manufacturer},{item.Model},{item.Combiner},{item.Headquarters},{item.Phone}");
                //Console.WriteLine($"{item.Manufacturer.Name}, {item.Manufacturer.Headquarters}, {item.Manufacturer.Phone}");
                //foreach (var car in item.Cars.OrderByDescending(c => c.Combined).Take(2))
                //{
                //    Console.WriteLine($"\t{car.Model}");
                //}

                Console.WriteLine($"Key: {item.Manufacturer}, Avg: {item.Avg}, Max: {item.Max}, Min: {item.Min}");
            }
        }

        private static List<Car> ProcessCars(string path)
        {
            // 读取文件
            var result = File.ReadAllLines(path)
                .Skip(1)
                .Where(item => item.Length > 1)
                .Select(line =>
            {
                var columns = line.Split(",");
                return new Car
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
            });
            return result.ToList();
        }

        private static List<Manufacturer> ProcessManufacturers(string path)
        {
            // 读取文件
            var result = File.ReadAllLines(path)
                .Skip(1)
                .Where(item => item.Length > 1)
                .Select(line =>
                {
                    var columns = line.Split(",");
                    return new Manufacturer
                    {
                        Name = columns[0],
                        Headquarters = columns[1],
                        Phone = columns[2],
                    };
                });
            return result.ToList();
        }
    }
}
