namespace 数据连接join
{
    internal class Car
    {
        public string Year { get; set; } = "null";
        public string Manufacturer { get; set; } = "null";
        public string Model { get; set; } = "null";

        public double Displacement { get; set; } = 0;
        public int CylindersCount { get; set; } = 0;
        public int City { get; set; } = 0;
        public int Highway { get; set; } = 0;
        public int Combined { get; set; } = 0;

        public Car() { }

        public override string? ToString()
        {
            return $"{Year},{Manufacturer},{Model},{Displacement},{CylindersCount},{City},{Highway},{Combined}";
        }
    }
}
