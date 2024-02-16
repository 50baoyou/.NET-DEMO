using System;

namespace MyEvent
{
    // 事件响应者
    internal class MailService
    {
        // 事件处理器（订单处理完成后，邮件服务器将发送邮件）
        internal static void OnOrderProcessed(Object order, OrderProcessorEventArgs eventArgs)
        {
            Console.WriteLine($"发送邮件，订单：{(order as Order)?.Id}，处理结果：{eventArgs.Description}，处理时间：{eventArgs.ProcessingTime}");
        }
    }
}
