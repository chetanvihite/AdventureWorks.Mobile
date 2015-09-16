

using System;

namespace AdventureWorks.Mobile.Services._001_Domain
{
    public class Order
    {
        public decimal OrderNumber { get; set; }
        public string DeliveryType { get; set; } // order type , standard/expedite/premium
        public string OrderType { get; set; } //ironing/washing+iron/dry clean
        public string PickupSchedule { get; set; } //morning/afternoon/evening/laterevening

        public string StreetAddress { get; set; }
        public string Landmark { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public decimal Pincode { get; set; }

        public DateTime OrderDate { get; set; }
        public string OrderStatus { get; set; }
        public DateTime PickupDate { get; set; }
        public DateTime CompletionDate { get; set; }
        public DateTime DeliveryDate { get; set; }

        public int ItemsCount { get; set; } //# of items

    }
}