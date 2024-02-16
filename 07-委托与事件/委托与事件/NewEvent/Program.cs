using MyEvent;
using System;

namespace NewEvent
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var order = new Order
            {
                Id = 1,
                DatePlaced = DateTime.Now,
                TotalPrice = 30f,
            };

            // 字段式事件声明
            var orderProcessor = new OrderProcessor();
            orderProcessor.orderProcessorEvent += SmsMessageService.OnOrderProcessed;  // 事件响应者
            orderProcessor.orderProcessorEvent += MailService.OnOrderProcessed;        // 事件响应者

            orderProcessor.Process(order);
        }
    }
}
