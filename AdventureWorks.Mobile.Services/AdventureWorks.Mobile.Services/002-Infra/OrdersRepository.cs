
using System;
using AdventureWorks.Mobile.Services._001_Domain;

namespace AdventureWorks.Mobile.Services._002_Infra
{
    public interface IOrdersRepository
    {
        void SubmitOrder(Order order);

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

        public void SubmitOrder(Order order)
        {
            var currentUnitOfWork = UnitOfWork as MainUnitOfWork;

            if (currentUnitOfWork == null) return;

            currentUnitOfWork.Orders.Add(order);

            currentUnitOfWork.SaveChanges();
        }
    }
}