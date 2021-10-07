using System;
using System.Collections.Generic;
using System.Text;

namespace Rz.DddDemo.Customers.Application.Queries.Customer
{
    public class PurchaseIncludes
    {
        public bool TotalPrice { get; set; }

        public bool Cancelled { get; set; }

        public bool CustomerId { get; set; }

        public bool PurchaseDate { get; set; }

        public PurchaseItemIncludes PurchaseItemIncludes { get; set; }
    }
}
