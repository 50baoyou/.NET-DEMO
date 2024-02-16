using System;

namespace OOP
{
    // 订单类
    public class Order
    {
        public int Id { get; set; }
        public DateTime DatePlaced { get; set; }
        public Shipment Shipment { get; set; }
        public float TotalPrice { get; set; }
        public bool IsShipped { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, " +
                $"DatePlaced: {DatePlaced}, " +
                $"Shipment: {Shipment.Cost}, " +
                $"TotalPrice: {TotalPrice}, " +
                $"IsShipped: {IsShipped}";

        }
    }
}
