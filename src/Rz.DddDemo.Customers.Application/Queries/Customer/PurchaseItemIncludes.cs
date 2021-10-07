using System;
using System.Collections.Generic;
using System.Text;

namespace Rz.DddDemo.Customers.Application.Queries.Customer
{
    public class PurchaseItemIncludes
    {
        public bool ProductName { get; set; }
        public bool Quantity { get; set; }
        public bool ProductPrice { get; set; }
        public bool TotalPrice { get; set; }
    }
}
