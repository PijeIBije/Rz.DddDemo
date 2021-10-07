using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Rz.DddDemo.Customers.Domain;
using Rz.DddDemo.Customers.Domain.Purchase;

namespace Rz.DddDemo.Customers.Infrastructure.PurchaseHistoryProvider.PurchaseHistoryProviderA.HttpClient
{
    public class PurchaseHistoryProviderA : IPurchaseHistoryProviderA
    {
        private readonly PurchaseHistoryProviderAHttpClient httpClient;

        public PurchaseHistoryProviderA(PurchaseHistoryProviderAHttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public Task<IEnumerable<PurchaseAggregate>> GetPurchases(CustomerId customerId, LegacyCustomerId legacyCustomerId)
        {
            return GetPurchases(customerId, legacyCustomerId, CancellationToken.None);
        }

        public async Task<IEnumerable<PurchaseAggregate>> GetPurchases(CustomerId customerId, LegacyCustomerId legacyCustomerId,
            CancellationToken cancellationToken)
        {
            var purchaseResources = await httpClient.GetPurchases(legacyCustomerId, cancellationToken);

            var result = purchaseResources.Select(x => new PurchaseAggregate(new PurchaseId(), customerId,
                x.PurchaseDate, x.Products.Select(y => new PurchaseItem(
                    y.Description,
                    y.Quantity,
                    y.PricePerItem)).ToList()));

            return result;
        }
    }
}
