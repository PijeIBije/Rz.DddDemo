using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Rz.DddDemo.Orders.Domain.Customer;
using Rz.DddDemo.Orders.Domain.Customer.Address.ValueObjects;
using Rz.DddDemo.Orders.Domain.Order;

namespace Rz.DddDemo.Orders.Application.Interfaces
{
    public interface IOrderRepository
    {
        public Task Save(OrderAggregate order);

        public Task Save(IEnumerable<OrderAggregate> orders);

        public Task<IEnumerable<OrderAggregate>> GetUnpaidWithCreateDateEarlierThan(DateTime createDate);

        public Task<OrderAggregate> GetById(OrderId orderId);

        public Task<IEnumerable<OrderAggregate>> GetNonShippedWithAddressNamesOrCustomerId(IEnumerable<AddressName> addressNames, CustomerId customerId);
    }
}
