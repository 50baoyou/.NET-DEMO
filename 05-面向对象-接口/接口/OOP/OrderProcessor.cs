using System;

namespace OOP
{
    // 订单处理系统类
    public class OrderProcessor : IOrderProcessor
    {
        // readonly 只能在声明期间或在同一个类的构造函数中向字段赋值
        private readonly IShippingController _shippingController;

        public OrderProcessor(IShippingController shippingController)
        {
            _shippingController = shippingController;
            Console.WriteLine("OrderProcessor 被创建了");
        }

        public void Process(Order order)
        {
            if (order.IsShipped)
            {
                throw new InvalidOperationException("订单已发货");
            }

            order.Shipment = new Shipment
            {
                Cost = _shippingController.GetCost(order),
                ShippingDate = DateTime.Today.AddDays(1)
            };

            order.IsShipped = true;

            Console.WriteLine($"订单#{order.Id}完成，已发货");
            Console.WriteLine(order.ToString());
        }
    }
}
