using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Rz.DddDemo.Customers.Domain;
using Rz.DddDemo.Customers.Domain.Purchase;
using Rz.DddDemo.PurchaseHistoryProviders.ProviderB.Protos;

namespace Rz.DddDemo.Customers.Infrastructure.PurchaseHistoryProvider.PurchaseHistoryProviderB.Grpc
{
    public class PurchaseHistoryProviderB : IPurchaseHistoryProviderB
    {
        private readonly CustomerDataServiceProto.CustomerDataServiceProtoClient customerDataService;

        public PurchaseHistoryProviderB(CustomerDataServiceProto.CustomerDataServiceProtoClient customerDataService)
        {
            this.customerDataService = customerDataService;
        }

        public Task<IEnumerable<PurchaseAggregate>> GetPurchases(CustomerId customerId,
            LegacyCustomerId legacyCustomerId)
        {
            return GetPurchases(customerId, legacyCustomerId, CancellationToken.None);
        }

        public async Task<IEnumerable<PurchaseAggregate>> GetPurchases(CustomerId customerId,
            LegacyCustomerId legacyCustomerId, CancellationToken cancellationToken)
        {
            var getPurchasesRequest = new PurchaseHistoryRequest
            {
                CustomerId = legacyCustomerId,
                IncludeReturned = false
            };

            var response = await customerDataService.GetPurchaseHistoryAsync(getPurchasesRequest,cancellationToken:cancellationToken);

            var purchases = response.Purchases.Select(x => new PurchaseAggregate(new PurchaseId(), customerId,
                x.PurchaseDate.ToDateTime(), x.Items.Select(y => new PurchaseItem(
                    y.Name,
                    y.Quantity,
                    (decimal)y.Price)).ToList()));

            return purchases;
        }
    }
}
