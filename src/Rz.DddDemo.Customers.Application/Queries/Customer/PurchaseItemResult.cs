using System;
using System.Collections.Generic;
using System.Text;

namespace Rz.DddDemo.Customers.Application.Queries.Customer
{
    public class PurchaseItemResult
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal ProductPrice { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
