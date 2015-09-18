

using System;
using AdventureWorks.Mobile.Services._001_Domain;

namespace AdventureWorks.Mobile.Services._002_Infra
{
    public class Repository
    {

        internal void SubmitOrder(Order order)
        {
            var connector = new DbConnector();

            connector.SubmitOrder(order);

        }
    }
}