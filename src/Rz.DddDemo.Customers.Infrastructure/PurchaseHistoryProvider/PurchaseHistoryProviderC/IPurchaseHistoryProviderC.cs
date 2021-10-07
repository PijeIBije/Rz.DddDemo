using Rz.DddDemo.Customers.Application.Interfaces;
using Rz.DddDemo.Customers.Infrastructure.PurchaseHistoryProvider.AggregatePurchaseHistoryProvider;

namespace Rz.DddDemo.Customers.Infrastructure.PurchaseHistoryProvider.PurchaseHistoryProviderC
{
    public interface IPurchaseHistoryProviderC : IPurchaseHistoryProvider, IGetPurchasesWithCancellation
    {
    }
}
