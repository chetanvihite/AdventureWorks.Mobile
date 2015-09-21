using System;
using AdventureWorks.Mobile.Services._002_Infra;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventureWorks.Mobile.Services._001_Domain;
using System.Configuration;

namespace Services.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //var connector = new DbConnector();
            //connector.Authenticate(8554983722, "cvihite123");

        }

        [TestMethod]
        public void AddOrder_should_save_into_database()
        {
            var order = new Order();
            order.MobileNumber = 456789;
            order.StreetAddress = "201 s heuights blvd";
            order.Landmark = "near allen pkwy";
            order.City = "bavdhan";
            order.State = "Maharashtra";
            order.Pincode = 411021;
            order.OrderDate = DateTime.Now;

            var repository = new OrdersRepository(
                new MainUnitOfWork(ConfigurationManager.AppSettings["AzureConnectionString"]));
            repository.SubmitOrder(order);


        }

        [TestMethod]
        public void Get_Next_order_number()
        {
            var repository = new OrdersRepository(
                new MainUnitOfWork(ConfigurationManager.AppSettings["AzureConnectionString"]));

            var result = repository.GetNextOrderNumber();
            Assert.IsNotNull(result);

        }

    }
}
