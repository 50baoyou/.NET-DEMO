using System;

namespace HelloWorld
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var order = new Order
            {
                Id = 443,
                DatePlaced = DateTime.Now,
                TotalPrice = 30f,
            };

            var orderProcessor = new OrderProcessor();

            orderProcessor.RegisterNotfication(new MailService());
            orderProcessor.RegisterNotfication(new SmsMessageService());

            orderProcessor.Process(order);

            Console.WriteLine("Hello World!");
        }
    }
}
