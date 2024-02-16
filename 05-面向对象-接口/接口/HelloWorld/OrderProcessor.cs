using System.Collections.Generic;

namespace HelloWorld
{
    internal class OrderProcessor
    {
        private readonly List<INotfication> _messageServices;

        public OrderProcessor()
        {
            _messageServices = new List<INotfication>();
        }

        public void RegisterNotfication(INotfication notfication)
        {
            _messageServices.Add(notfication);
        }

        public void Process(Order order)
        {
            // 处理订单...处理发货...

            // 通知用户收货
            foreach (var item in _messageServices)
            {
                item.Send($"订单 {order.Id} 已发货");
            }
        }
    }
}

