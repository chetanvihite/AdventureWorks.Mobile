using AdventureWorks.Mobile.Services._001_Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace AdventureWorks.Mobile.Services._002_Infra.EF.Mappings
{
    public class OrdersMap : EntityTypeConfiguration<Order>
    {
        public OrdersMap()
        {
            ToTable("ORDERS", "ADVENTUREWORKS.DB");

            HasKey(x => new { x.OrderNumber });

            Property(x => x.OrderNumber).HasColumnName("ORDERNUMBER");
            Property(x => x.MobileNumber).HasColumnName("MOBILENUMBER");
            Property(x => x.DeliveryType).HasColumnName("DELIVERYTYPE");
            Property(x => x.OrderType).HasColumnName("ORDERTYPE");
            Property(x => x.PickupSchedule).HasColumnName("PICKUPSCHEDULE");
            Property(x => x.StreetAddress).HasColumnName("STREETADDRESS");
            Property(x => x.Landmark).HasColumnName("LANDMARK");
            Property(x => x.City).HasColumnName("CITY");
            Property(x => x.State).HasColumnName("STATE");
            Property(x => x.Pincode).HasColumnName("PINCODE");

            Property(x => x.OrderDate).HasColumnName("ORDER_DATE");
            Property(x => x.OrderStatus).HasColumnName("ORDERSTATUS");
            Property(x => x.PickupDate).HasColumnName("PICKUPDATE");
            Property(x => x.CompletionDate).HasColumnName("COMPLETIONDATE");
            Property(x => x.DeliveryDate).HasColumnName("DELIVERYDATE");
            Property(x => x.ItemsCount).HasColumnName("ITEMSCOUNT");

        }
    }
}