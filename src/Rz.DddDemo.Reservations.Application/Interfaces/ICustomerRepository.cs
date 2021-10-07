using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rz.DddDemo.Reservations.Domain.Customer;

namespace Rz.DddDemo.Reservations.Application.Interfaces
{
    public interface ICustomerRepository
    {
        Task<CustomerAggregate> GetById(CustomerId customerId);

        Task Save(CustomerAggregate customerAggregate);
    }
}
