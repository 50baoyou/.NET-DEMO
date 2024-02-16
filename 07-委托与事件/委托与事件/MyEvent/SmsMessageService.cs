using System;

namespace MyEvent
{
    // 事件响应者
    internal class SmsMessageService
    {
        // 事件处理器（订单处理完成后，短信服务器将发送短信）
        internal static void OnOrderProcessed(Order order, OrderProcessorEventArgs eventArgs)
        {
            Console.WriteLine($"发送短信，订单：{order.Id}，处理结果：{eventArgs.Description}，处理时间：{eventArgs.ProcessingTime}");
        }
    }
}
