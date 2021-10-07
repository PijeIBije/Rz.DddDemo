using System.Collections.Generic;
using Rz.DddDemo.Base.Application;
using Rz.DddDemo.Base.Application.CommandHandling.Interfaces;
using Rz.DddDemo.Customers.Domain;

namespace Rz.DddDemo.Customers.Application.Commands.Customer
{
    public class UpdateCustomerCommand:ICommand<NoResult>
    {
        public CustomerId CustomerId { get; set; }
        public Name Name { get; set; }
        public PhoneNumber PhoneNumber { get; set; }
        public EmailAddress EmailAddress { get; set; }
    }
}
