using System;
using System.Collections.Generic;

namespace Rz.DddDemo.PurchaseHistoryProviders.ProviderA.Controllers
{
    public class PurchaseResource
    {
        public DateTime PurchaseDate { get; set; }

        public List<ProductResource> Products { get; set; }

        public bool Returned { get; set; }
    }
}
