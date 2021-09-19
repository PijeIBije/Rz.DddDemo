using System.Collections.Generic;
using Rz.DddDemo.Orders.Domain.Customer;

namespace Rz.DddDemo.Orders.Infrastructure.CustomerRepository.EntityFrameworkWithDapper
{
    public class CustomerDto
    {
        public FirstName FirstName { get; set; }
        public LastName LastName { get;  set; }
        public List<AddressDto> Addresses { get; set; }
    }
}
