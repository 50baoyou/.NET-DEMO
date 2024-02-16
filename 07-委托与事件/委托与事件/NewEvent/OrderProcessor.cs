using System;

namespace MyEvent
{
    public class OrderProcessorEventArgs : EventArgs
    {
        public string Status { get; set; }
        public DateTime ProcessingTime { get; set; }
        public string Description { get; set; }
    }

    public class OrderProcessor
    {
        // 预定义事件
        public event EventHandler<OrderProcessorEventArgs> orderProcessorEvent;

        public void Process(Order order)
        {
            // 订单处理...

            // 订单处理完成，发送订单处理完成事件
            if (orderProcessorEvent != null) // 有事件处理器才发送事件
            {
                var eventArgs = new OrderProcessorEventArgs
                {
                    Status = "completed",
                    ProcessingTime = DateTime.Now, // UtcNow: 0时区
                    Description = "success！"
                };
                orderProcessorEvent(order, eventArgs);
            }
        }
    }
}
