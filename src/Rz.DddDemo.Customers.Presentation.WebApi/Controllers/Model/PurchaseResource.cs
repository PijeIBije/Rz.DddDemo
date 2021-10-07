using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rz.DddDemo.Customers.Presentation.WebApi.Controllers.Model
{
    public class PurchaseResource
    {
        public decimal TotalPrice { get; set; }

        public bool Cancelled { get; set; }

        public Guid CustomerId { get; set; }

        public DateTime PurchaseDate { get; set; }

        public List<PurchaseItemResource> Items{ get; set; }
    }
}
