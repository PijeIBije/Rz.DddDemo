using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Rz.DddDemo.Customers.Domain;
using Rz.DddDemo.Customers.Domain.Purchase;

namespace Rz.DddDemo.Customers.Infrastructure.PurchaseHistoryProvider.PurchaseHistoryProviderB.Mock
{
    public class PurchaseHistoryProviderB : IPurchaseHistoryProviderB
    {
        public async Task<IEnumerable<PurchaseAggregate>> GetPurchases(CustomerId customerId,
            LegacyCustomerId legacyCustomerId)
        {
            if (((string)legacyCustomerId).EndsWith("B"))
            {
                await Task.Delay(10000);
            }

            return await GetPurchases(customerId, legacyCustomerId, CancellationToken.None);
        }

        public Task<IEnumerable<PurchaseAggregate>> GetPurchases(CustomerId customerId,
            LegacyCustomerId legacyCustomerId, CancellationToken cancellationToken)
        {
            return Task.FromResult(GetMockData(customerId));
        }

        private static IEnumerable<PurchaseAggregate> GetMockData(CustomerId customerId) =>
            new List<PurchaseAggregate>
            {
                new PurchaseAggregate
                (
                    new PurchaseId(),
                    customerId,
                    DateTime.Now.AddMonths(-1),
                    new List<PurchaseItem>
                    {
                        new PurchaseItem
                        (
                            "Tickets for Pan Tadeush Premium Seats",
                            2,
                            100m
                        ),

                        new PurchaseItem
                        (
                            "Tickets for Pan Tadeush Plebeyan Seats`",
                            20,
                            20m
                        ),
                    }
                ),
                new PurchaseAggregate
                (
                    new PurchaseId(),
                    customerId,
                    DateTime.Now.AddMonths(-3),
                    new List<PurchaseItem>
                    {
                        new PurchaseItem
                        (
                            "Limited theatree pencil",
                            1,
                            13.55m
                        )
                    }
                )
            };
    }
}
