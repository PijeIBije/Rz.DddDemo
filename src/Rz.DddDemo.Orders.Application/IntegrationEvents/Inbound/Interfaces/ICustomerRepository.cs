using System;
using System.Collections.Generic;
using System.Text;
using Rz.DddDemo.Orders.Domain.Customer;
using Rz.DddDemo.Orders.Domain.Customer.ValueObjects;

namespace Rz.DddDemo.Orders.Application.IntegrationEvents.Inbound.Interfaces
{
    public interface ICustomerRepository
    {
        public void Save(Customer customer);

        public Customer TryGetById(CustomerId customerId);
    }
}
