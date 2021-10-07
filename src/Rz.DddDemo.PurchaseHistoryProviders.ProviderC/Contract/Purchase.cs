using System;
using System.Collections.Generic;

namespace Rz.DddDemo.PurchaseHistoryProviders.ProviderC.Contract
{
    public class Purchase
    {
        public DateTime Date { get; set; }

        public List<Item> Items { get; set; }

        public bool Returned { get; set; }
    }
}