using Rz.DddDemo.Customers.Application.Interfaces;
using Rz.DddDemo.Customers.Infrastructure.PurchaseHistoryProvider.AggregatePurchaseHistoryProvider;

namespace Rz.DddDemo.Customers.Infrastructure.PurchaseHistoryProvider.PurchaseHistoryProviderA
{
    public interface IPurchaseHistoryProviderA:IPurchaseHistoryProvider,IGetPurchasesWithCancellation
    {
    }
}
