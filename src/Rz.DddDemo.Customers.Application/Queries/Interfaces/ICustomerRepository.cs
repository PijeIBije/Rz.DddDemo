using System.Collections.Generic;
using System.Threading.Tasks;
using Rz.DddDemo.Customers.Application.Queries.Customer;
using Rz.DddDemo.Customers.Domain.ValueObjects;

namespace Rz.DddDemo.Customers.Application.Queries.Interfaces
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<CustomerResult>> Get(CustomerId customerId, CustomerIncludes customerIncludes);
    }
}
