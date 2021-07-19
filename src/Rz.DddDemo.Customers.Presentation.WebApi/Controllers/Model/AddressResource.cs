using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rz.DddDemo.Customers.Domain.CustomerAggregate.AddressAggregate.ValueObjects;
using Rz.DddDemo.Customers.Domain.CustomerAggregate.ValueObjects;
using Rz.DddDemo.Base.Presentation.WebApi.Validation;

namespace Rz.DddDemo.Customers.Presentation.WebApi.Controllers.Model
{
    public class AddressResource
    {
        [ValidateAsType(typeof(AddressName))]
        public string Name { get; set; }

        [ValidateAsType(typeof(AddressLine))]
        public string AddressLine1 { get; set; }

        [ValidateAsType(typeof(AddressLine))]
        public string AddressLine2 { get; set; }

        [ValidateAsType(typeof(City))]
        public string City { get; set; }

        [ValidateAsType(typeof(PhoneNumber))]
        public string PhoneNumber { get; set; }

        [ValidateAsType(typeof(EmailAddress))]
        public string EmailAddress { get; set; }

        [ValidateAsType(typeof(Country))]
        public string Country { get; set; }
    }
}
