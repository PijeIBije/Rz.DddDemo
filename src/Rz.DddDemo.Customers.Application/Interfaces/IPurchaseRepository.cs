using System.Collections.Generic;
using System.Threading.Tasks;
using Rz.DddDemo.Customers.Domain.Purchase;

namespace Rz.DddDemo.Customers.Application.Interfaces
{
    public interface IPurchaseRepository
    {
        Task Save(PurchaseAggregate purchase);

        Task Save(IEnumerable<PurchaseAggregate> purchases);
    }
}
