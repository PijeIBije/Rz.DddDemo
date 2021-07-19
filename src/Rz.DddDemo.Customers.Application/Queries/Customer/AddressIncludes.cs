using System;
using System.Collections.Generic;
using System.Text;

namespace Rz.DddDemo.Customers.Application.Queries.Customer
{
    public class AddressIncludes
    {
        public bool Name { get; set; }
        public bool AddressLine1 { get; set; }
        public bool AddressLine2 { get; set; }
        public bool City { get; set; }
        public bool PhoneNumber { get; set; }
        public bool EmailAddress { get; set; }
        public bool Country { get; set; }
    }
}
