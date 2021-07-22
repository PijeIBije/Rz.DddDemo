using System.Threading.Tasks;
using Rz.DddDemo.Orders.Domain.Customer;
using Rz.DddDemo.Orders.Domain.Customer.ValueObjects;

namespace Rz.DddDemo.Orders.Application.Interfaces
{
    public interface ICustomerRepository
    {
        public Task<CustomerAggregate> GetById(CustomerId customerId);
    }
}
