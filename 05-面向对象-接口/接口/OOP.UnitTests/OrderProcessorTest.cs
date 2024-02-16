using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace OOP.UnitTests
{
    [TestClass]
    public class OrderProcessorTest
    {
        // ��������
        // ���������ⷽ��_����_�������
        [TestMethod]
        public void Process_OrderUnshipped_SetShippment()
        {
            OrderProcessor orderProcessor = new(new FakeShippingCalculator());

            var order = new Order()
            {
                Id = 123,
                DatePlaced = DateTime.Now,
                TotalPrice = 100f,
                IsShipped = false,
                Shipment = null
            };

            orderProcessor.Process(order);

            //  ����
            Assert.AreEqual(order.Shipment.Cost, 5);
            Assert.IsTrue(order.IsShipped);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Process_OrderIsshipped_ThrowException()
        {
            OrderProcessor orderProcessor = new(new FakeShippingCalculator());

            var order = new Order()
            {
                Id = 123,
                DatePlaced = DateTime.Now,
                TotalPrice = 100f,
                IsShipped = true,
                Shipment = null
            };

            orderProcessor.Process(order);
        }
    }
}
