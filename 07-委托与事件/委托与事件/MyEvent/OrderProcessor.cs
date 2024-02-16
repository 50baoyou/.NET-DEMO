using System;

namespace MyEvent
{
    // 事件相关信息类
    public class OrderProcessorEventArgs : EventArgs
    {
        public string Status { get; set; }
        public DateTime ProcessingTime { get; set; }
        public string Description { get; set; }
    }

    // 事件处理器，事件基于委托
    public delegate void OrderProcessorEventHandler(Order order, OrderProcessorEventArgs eventArgs);

    // 事件拥有者
    public class OrderProcessor
    {
        // 事件处理器
        private OrderProcessorEventHandler _orderProcessorEventHandler;

        // 事件，特殊结构
        public event OrderProcessorEventHandler orderProcessorEvent
        {
            // 绑定/订阅 事件处理器
            add
            {
                // 多播委托，支持多个事件处理器
                this._orderProcessorEventHandler += value;
            }
            // 移除事件处理器
            remove
            {
                this._orderProcessorEventHandler -= value;
            }
        }

        public void Process(Order order)
        {
            // 订单处理...

            // 订单处理完成，发送订单处理完成事件
            if (_orderProcessorEventHandler != null) // 有事件处理器才发送事件
            {
                var eventArgs = new OrderProcessorEventArgs
                {
                    Status = "completed",
                    ProcessingTime = DateTime.Now, // UtcNow: 0时区
                    Description = "success！"
                };
                _orderProcessorEventHandler(order, eventArgs);
            }
        }
    }
}
