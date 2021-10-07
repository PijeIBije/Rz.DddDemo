using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Rz.DddDemo.Customers.Application.Interfaces;
using Rz.DddDemo.Customers.Domain;
using Rz.DddDemo.Customers.Domain.Purchase;
using Rz.DddDemo.Customers.Infrastructure.PurchaseHistoryProvider.AggregatePurchaseHistoryProvider;

namespace Rz.DddDemo.Customers.Infrastructure.PurchaseHistoryProvider.PurchaseHistoryProviderC.Wcf
{
    public class GetLegacyPurchasesOperation : IPurchaseHistoryProvider, IGetPurchasesWithCancellation
    {
        public GetLegacyPurchasesOperation()
        {
            
        }

        public Task<IEnumerable<PurchaseAggregate>> GetPurchases(CustomerId customerId, LegacyCustomerId legacyCustomerId)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<PurchaseAggregate>> GetPurchases(CustomerId customerId, LegacyCustomerId legacyCustomerId,
            CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
