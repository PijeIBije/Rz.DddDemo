using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Rz.DddDemo.PurchaseHistoryProviders.ProviderC.Contract;

namespace Rz.DddDemo.PurchaseHistoryProviders.ProviderC
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class CustomerDataService : ICustomerDataService
    {
        public GetPurchasesResponse GetPurchases(GetPurchasesRequest request)
        {
            if (request.CustomerId.EndsWith("C"))
            {
                Thread.Sleep(10000);
            }

            return new GetPurchasesResponse
            {
                Purchases = MockData.Where(x=>request.IncludeReturned || !x.Returned).ToList()
            };
        }

        private static readonly List<Purchase> MockData = new List<Purchase>
        {
            new Purchase
            {
                Date = DateTime.Now.AddMonths(-1),
                Items = new List<Item>
                {
                    new Item
                    {
                        Name = "Tickets for Pan Tadeush Premium Seats",
                        Price = 100,
                        Count = 2
                    },

                    new Item
                    {
                        Name = "Tickets for Pan Tadeush Plebeyan Seats`",
                        Price = 20,
                        Count = 20
                    },
                }
            },
            new Purchase
            {
                Date = DateTime.Now.AddMonths(-3),
                Items = new List<Item>
                {
                    new Item
                    {
                        Name = "Limited theatree pencil",
                        Price = 13.55m,
                        Count = 1
                    }
                }
            },
            new Purchase
            {
                Date = DateTime.Now.AddMonths(-5),
                Items = new List<Item>
                {
                    new Item
                    {
                        Name = "Tickets for Antygona",
                        Price = 20m,
                        Count = 1,
                    }
                },
                Returned = true
            },
        };
    }
}
