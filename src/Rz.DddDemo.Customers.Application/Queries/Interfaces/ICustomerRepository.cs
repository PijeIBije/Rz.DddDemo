using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Rz.DddDemo.Customers.Application.Queries.Customer;
using Rz.DddDemo.Customers.Domain.CustomerAggregate.ValueObjects;

namespace Rz.DddDemo.Customers.Application.Queries.Interfaces
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<CustomerResult>> Get(CustomerId customerId, CustomerIncludes customerIncludes);
    }
}
