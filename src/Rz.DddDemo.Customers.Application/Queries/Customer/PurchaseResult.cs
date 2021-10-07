using System;
using System.Collections.Generic;
using System.Text;

namespace Rz.DddDemo.Customers.Application.Queries.Customer
{
    public class PurchaseResult
    {
        public decimal TotalPrice { get; set; }

        public bool Cancelled { get; set; }

        public Guid CustomerId { get; set; }

        public DateTime PurchaseDate { get; set; }

        public List<PurchaseItemResult> PurchaseResults { get; set; }
    }
}
