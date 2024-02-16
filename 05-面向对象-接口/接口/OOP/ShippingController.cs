using System;
using System.Collections.Generic;
using System.Linq;

namespace OOP
{
    public class ShippingController : IShippingController
    {
        private readonly IEnumerable<IShippingCalculator> _shippingCalculators;

        public ShippingController(IEnumerable<IShippingCalculator> shippingCalculators)
        {
            _shippingCalculators = shippingCalculators;
            Console.WriteLine("ShippingController 被创建了");
            Console.WriteLine(_shippingCalculators.Count());
        }

        private IShippingCalculator GetShippingCalculator()
        {
            IShippingCalculator shippingCalculator;

            if (DateTime.Now.Month == 11 && DateTime.Now.Day == 11)
            {
                Console.WriteLine("今天是“双十一”");
                shippingCalculator = _shippingCalculators.FirstOrDefault(c => c is DobleElevenShippingCalculator);
            }
            else
            {
                Console.WriteLine("今天不是“双十一”");
                shippingCalculator = _shippingCalculators.FirstOrDefault(c => c is ShippingCalculator);
            }

            return shippingCalculator;
        }

        public float GetCost(Order order)
        {
            return GetShippingCalculator().CalculateShipping(order);
        }
    }
}
