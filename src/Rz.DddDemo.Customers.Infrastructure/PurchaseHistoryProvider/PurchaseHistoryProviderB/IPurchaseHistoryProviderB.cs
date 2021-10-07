using Rz.DddDemo.Customers.Application.Interfaces;
using Rz.DddDemo.Customers.Infrastructure.PurchaseHistoryProvider.AggregatePurchaseHistoryProvider;

namespace Rz.DddDemo.Customers.Infrastructure.PurchaseHistoryProvider.PurchaseHistoryProviderB
{
    public interface IPurchaseHistoryProviderB : IPurchaseHistoryProvider, IGetPurchasesWithCancellation
    {
    }
}
