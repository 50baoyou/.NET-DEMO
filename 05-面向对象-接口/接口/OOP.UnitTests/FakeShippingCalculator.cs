namespace OOP.UnitTests
{
    internal class FakeShippingCalculator : IShippingCalculator
    {
        public float CalculateShipping(Order order)
        {
            return 5;
        }
    }
}
