using System;
using System.Collections.Generic;
using Rz.DddDemo.Base.Presentation.WebApi.Validation;
using Rz.DddDemo.Customers.Domain;

namespace Rz.DddDemo.Customers.Presentation.WebApi.Controllers.Model
{
    public class CustomerResource
    {
        [ValidateAsType(typeof(CustomerId))]
        public Guid Id { get; set; }

        [ValidateAsType(typeof(Name))]
        public string Name { get; set; }

        [ValidateAsType(typeof(EmailAddress))]
        public string EmailAddress { get; set; }

        [ValidateAsType(typeof(PhoneNumber))]
        public string PhoneNumber { get; set; }

        [ValidateAsType(typeof(LegacyCustomerId))]
        public string LegacyCustomerId { get; set; }

        public List<PurchaseResource> Purchases { get; set; }
    }
}
