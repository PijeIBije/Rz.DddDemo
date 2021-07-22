using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Rz.DddDemo.Orders.Domain.Order;

namespace Rz.DddDemo.Orders.Application.Interfaces
{
    public interface IOrderRepository
    {
        public Task Save(OrderAggregate order);

        public Task Save(IEnumerable<OrderAggregate> orders);

        public Task<IEnumerable<OrderAggregate>> GetUnpaidWithCreateDateEarlierThan(DateTime createDate);
    }
}
