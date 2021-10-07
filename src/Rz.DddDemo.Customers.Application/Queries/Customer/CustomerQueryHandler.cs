using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Rz.DddDemo.Base.Application.QueryHandling.Intefaces;
using Rz.DddDemo.Customers.Application.Interfaces;

namespace Rz.DddDemo.Customers.Application.Queries.Customer
{
    public class CustomerQueryHandler:IQueryHandler<CustomerQuery,IEnumerable<CustomerResult>>
    {
        private readonly ICustomerRepository customerRepository;

        public CustomerQueryHandler(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public Task<IEnumerable<CustomerResult>> Handle(CustomerQuery query,CancellationToken cancellationToken)
        {
            return customerRepository.Get(query.CustomerId, query.CustomerIncludes,cancellationToken);
        }
    }
}
