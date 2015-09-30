

using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdventureWorks.Mobile.Services._001_Domain
{
    public class OrderDetails
    {
        public decimal OrderNumber { get; set; }

        public int Shirts { get; set; }
        public int Trousers { get; set; }
        public int TShirts { get; set; }
        public int Sheets { get; set; }

        public int Sarees { get; set; }

    }
    public class Order : BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal OrderNumber { get; set; }

        public decimal MobileNumber { get; set; }
        public string DeliveryType { get; set; } // order type , standard/expedite/premium
        public string OrderType { get; set; } //ironing/washing+iron/dry clean
        public int PickupSchedule { get; set; } //morning/afternoon/evening/later evening

        public string StreetAddress { get; set; }
        public string Landmark { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public decimal Pincode { get; set; }

        public DateTime OrderDate { get; set; }
        public string OrderStatus { get; set; }
        public DateTime? PickupDate { get; set; }
        public DateTime? CompletionDate { get; set; } 
        public DateTime? DeliveryDate { get; set; }

        public string AssignedTo { get; set; }

        public DateTime? AssignedDate { get; set; }
        public int ItemsCount { get; set; } //# of items

    }
}