using System;
using System.Collections.Generic;
using System.Text;
using Rz.DddDemo.Base.Application.CommandHandling.Interfaces;
using Rz.DddDemo.Customers.Domain.CustomerAggregate.ValueObjects;

namespace Rz.DddDemo.Customers.Application.Commands.Customer
{
    public class CreateCustomerCommand:ICommand
    {
        public CustomerId CustomerId { get; set; }
        public FirstName FirstName { get; set; }
        public LastName LastName { get; set; }
        public DateOfBirth DateOfBirth { get; set; }
        public List<AddressData> Addresses { get; set; }
    }
}
