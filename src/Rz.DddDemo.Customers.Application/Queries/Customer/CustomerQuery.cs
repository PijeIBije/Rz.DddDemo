using Rz.DddDemo.Base.Application.QueryHandling.Intefaces;
using Rz.DddDemo.Customers.Domain.ValueObjects;

namespace Rz.DddDemo.Customers.Application.Queries.Customer
{
    public class CustomerQuery:IQuery
    {
        public CustomerId CustomerId { get; set; }

        public CustomerIncludes CustomerIncludes { get; set; }
    }
}
