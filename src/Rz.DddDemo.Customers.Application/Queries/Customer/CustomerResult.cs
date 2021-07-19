using System;
using System.Collections.Generic;
using System.Text;
using Rz.DddDemo.Base.Application.QueryHandling.Intefaces;

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
