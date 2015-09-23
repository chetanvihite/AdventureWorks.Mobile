
using System;
using AdventureWorks.Mobile.Services._001_Domain;
using System.Linq;

namespace AdventureWorks.Mobile.Services._002_Infra
{
    public interface IOrdersRepository
    {
        Order GetOrder(decimal orderNumber);
        void SubmitOrder(Order order);
        void UpdateOrder(Order oldOrder, Order newOrder);
    }

    public class OrdersRepository : BaseRepository<Order>, IOrdersRepository
    {
        private readonly MainUnitOfWork _accusUnitOfWork;

        public OrdersRepository(IQueryableUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _accusUnitOfWork = unitOfWork as MainUnitOfWork;
            if (_accusUnitOfWork == null) throw new Exception("main unit of work cant be null");
        }

        public Order GetOrder(decimal orderNumber)
        {
            var currentUnitOfWork = UnitOfWork as MainUnitOfWork;

            if (currentUnitOfWork == null) return null;

            return Find(o => o.OrderNumber == orderNumber).FirstOrDefault();
        }

        public void SubmitOrder(Order order)
        {
            var currentUnitOfWork = UnitOfWork as MainUnitOfWork;

            if (currentUnitOfWork == null) return;

            currentUnitOfWork.Orders.Add(order);

            currentUnitOfWork.SaveChanges();
        }

        public void UpdateOrder(Order oldOrder, Order newOrder)
        {
            var currentUnitOfWork = UnitOfWork as MainUnitOfWork;

            if (currentUnitOfWork == null) return;

            currentUnitOfWork.ApplyCurrentValues(oldOrder, newOrder);

            currentUnitOfWork.SaveChanges();            
        }

        public OrderNumberHolder GetNextOrderNumber()
        {
            var currentUnitOfWork = UnitOfWork as MainUnitOfWork;
            if (currentUnitOfWork == null) return null;

            var result = currentUnitOfWork.ExecuteQuery<OrderNumberHolder>("select NEXT VALUE FOR orderssequence as [NEXTVAL]");

            return result.FirstOrDefault();
        }
    }
}