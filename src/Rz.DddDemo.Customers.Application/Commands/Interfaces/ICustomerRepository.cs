using System.Threading.Tasks;
using Rz.DddDemo.Customers.Domain;
using Rz.DddDemo.Customers.Domain.ValueObjects;

namespace Rz.DddDemo.Customers.Application.Commands.Interfaces
{
    public interface ICustomerRepository
    {
        Task<CustomerAggregate> GetById(CustomerId customerId);

        Task Save(CustomerAggregate customerEntity);
    }
}
