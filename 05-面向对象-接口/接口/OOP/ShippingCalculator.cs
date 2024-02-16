using System;

namespace OOP
{
    // 运费计算类
    internal class ShippingCalculator : IShippingCalculator
    {
        public ShippingCalculator()
        {
            Console.WriteLine("ShippingCalculator 被创建了");
        }

        public float CalculateShipping(Order order)
        {
            if (order.TotalPrice < 30f)
            {
                return order.TotalPrice * 0.1f;
            }
            return 0;
        }
    }
}
