using System;

namespace MyEvent
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

            /**
             * 事件五要素：事件，事件拥有者，事件响应者，事件处理器，事件订阅
             */
            // 配置完整事件声明
            var orderProcessor = new OrderProcessor();
            // 订阅事件
            orderProcessor.orderProcessorEvent += SmsMessageService.OnOrderProcessed;  // 事件响应者
            orderProcessor.orderProcessorEvent += MailService.OnOrderProcessed;        // 事件响应者
            orderProcessor.Process(order);

        }
    }
}
