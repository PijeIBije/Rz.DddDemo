using System;
using System.Collections.Generic;

namespace Rz.DddDemo.Customers.Application.Queries.Customer
{
    public class CustomerResult
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime EmailAddress { get; set; }
        public List<PurchaseResult> Addresses { get; set; } = new List<PurchaseResult>();
    }
}
