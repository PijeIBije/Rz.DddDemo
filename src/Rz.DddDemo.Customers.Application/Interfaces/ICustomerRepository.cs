using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Rz.DddDemo.Customers.Application.Queries.Customer;
using Rz.DddDemo.Customers.Domain;

namespace Rz.DddDemo.Customers.Application.Interfaces
{
    public interface ICustomerRepository
    {
        Task<CustomerAggregate> GetById(CustomerId customerId);

        Task Save(CustomerAggregate customerEntity);

        Task<IEnumerable<CustomerResult>> Get(CustomerId customerId, CustomerIncludes customerIncludes,CancellationToken cancellationToken);
    }
}
