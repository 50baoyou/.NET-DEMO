using System;

namespace OOP
{
    // 双十一运费计算类
    internal class DobleElevenShippingCalculator : IShippingCalculator
    {
        public DobleElevenShippingCalculator()
        {
            Console.WriteLine("DobleElevenShippingCalculator 被创建了");
        }

        public float CalculateShipping(Order order)
        {
            return 0;
        }
    }
}
