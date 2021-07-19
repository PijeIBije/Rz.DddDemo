using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rz.DddDemo.Customers.Application.Queries.Customer;
using Rz.DddDemo.Customers.Domain.CustomerAggregate.ValueObjects;
using Rz.DddDemo.Base.Presentation.WebApi.Validation;

namespace Rz.DddDemo.Customers.Presentation.WebApi.Controllers.Model
{
    public class CustomerResource
    {
        [ValidateAsType(typeof(CustomerId))]
        public Guid Id { get; set; }

        [ValidateAsType(typeof(FirstName))]
        public string FirstName { get; set; }

        [ValidateAsType(typeof(LastName))]
        public string LastName { get; set; }


        public DateTime DateOfBirth { get; set; }
        public List<AddressResource> Addresses { get; set; } = new List<AddressResource>();
    }
}
