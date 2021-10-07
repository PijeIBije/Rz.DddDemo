using System.Collections.Generic;
using System.Threading.Tasks;
using Rz.DddDemo.Customers.Domain;
using Rz.DddDemo.Customers.Domain.Purchase;

namespace Rz.DddDemo.Customers.Application.Interfaces
{
    public interface IPurchaseHistoryProvider
    {
        Task<IEnumerable<PurchaseAggregate>> GetPurchases(CustomerId customerId, LegacyCustomerId legacyCustomerId);
    }
}
