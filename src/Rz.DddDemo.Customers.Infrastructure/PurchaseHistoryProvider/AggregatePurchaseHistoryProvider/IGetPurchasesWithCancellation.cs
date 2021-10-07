using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Rz.DddDemo.Customers.Domain;
using Rz.DddDemo.Customers.Domain.Purchase;

namespace Rz.DddDemo.Customers.Infrastructure.PurchaseHistoryProvider.AggregatePurchaseHistoryProvider
{
    public interface IGetPurchasesWithCancellation
    {
        Task<IEnumerable<PurchaseAggregate>> GetPurchases(CustomerId customerId, LegacyCustomerId legacyCustomerId,
        CancellationToken cancellationToken);
    }
}
