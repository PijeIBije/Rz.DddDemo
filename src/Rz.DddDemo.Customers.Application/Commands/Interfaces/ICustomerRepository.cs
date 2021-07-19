using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Rz.DddDemo.Customers.Domain;
using Rz.DddDemo.Customers.Domain.CustomerAggregate.ValueObjects;

namespace Rz.DddDemo.Customers.Application.Commands.Interfaces
{
    public interface ICustomerRepository
    {
        Task<Domain.CustomerAggregate.Customer> GetById(CustomerId customerId);

        Task Save(Domain.CustomerAggregate.Customer customerEntity);
    }
}
