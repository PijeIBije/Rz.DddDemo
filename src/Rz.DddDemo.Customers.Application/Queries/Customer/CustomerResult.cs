using System;
using System.Collections.Generic;

namespace Rz.DddDemo.Customers.Application.Queries.Customer
{
    public class CustomerResult
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public List<AddressResult> Addresses { get; set; } = new List<AddressResult>();
    }
}
