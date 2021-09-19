using System.Threading.Tasks;
using Rz.DddDemo.Orders.Application.Interfaces;
using Rz.DddDemo.Orders.Domain.Customer;

namespace Rz.DddDemo.Orders.Infrastructure.CustomerRepository.EntityFrameworkWithDapper
{
    public class CustomerRepository:ICustomerRepository

    {
        public Task<CustomerAggregate> GetById(CustomerId customerId)
        {
            throw new System.NotImplementedException();
        }

        public Task Save(CustomerAggregate customer)
        {
            throw new System.NotImplementedException();
        }

        public Task<CustomerAggregate> TryGetById(CustomerId customerId)
        {
            throw new System.NotImplementedException();
        }
    }
}
