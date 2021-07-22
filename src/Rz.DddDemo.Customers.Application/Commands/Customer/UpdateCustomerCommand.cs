using System.Collections.Generic;
using Rz.DddDemo.Base.Application.CommandHandling.Interfaces;
using Rz.DddDemo.Customers.Domain.Address.ValueObjects;
using Rz.DddDemo.Customers.Domain.ValueObjects;

namespace Rz.DddDemo.Customers.Application.Commands.Customer
{
    public class UpdateCustomerCommand:ICommand
    {
        public CustomerId CustomerId { get; set; }
        public FirstName FirstName { get; set; }
        public LastName LastName { get; set; }
        public DateOfBirth DateOfBirth { get; set; }
        public List<AddressUpdate> AddressesToAddOrUpdate { get; set; }
        public List<AddressName> AddresesToRemoveNames { get; set; }
    }
}
