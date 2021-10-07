using System;
using System.Collections.Generic;

namespace Rz.DddDemo.Customers.Infrastructure.PurchaseHistoryProvider.PurchaseHistoryProviderA.HttpClient.Model
{
    public class PurchaseResource
    {
        public DateTime PurchaseDate { get; set; }

        public List<ProductResource> Products { get; set; }

        public bool Returned { get; set; }
    }
}
