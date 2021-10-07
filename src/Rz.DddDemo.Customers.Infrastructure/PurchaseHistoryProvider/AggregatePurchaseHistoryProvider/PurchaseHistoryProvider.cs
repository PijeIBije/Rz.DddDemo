using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Rz.DddDemo.Customers.Application.Interfaces;
using Rz.DddDemo.Customers.Domain;
using Rz.DddDemo.Customers.Domain.Purchase;
using Rz.DddDemo.Customers.Infrastructure.PurchaseHistoryProvider.PurchaseHistoryProviderA;
using Rz.DddDemo.Customers.Infrastructure.PurchaseHistoryProvider.PurchaseHistoryProviderB;
using Rz.DddDemo.Customers.Infrastructure.PurchaseHistoryProvider.PurchaseHistoryProviderC;
using Rz.DddDemo.Customers.Infrastructure.PurchaseHistoryProvider.PurchaseHistoryProviderC.Wcf;

namespace Rz.DddDemo.Customers.Infrastructure.PurchaseHistoryProvider.AggregatePurchaseHistoryProvider
{
    public class PurchaseHistoryProvider:IPurchaseHistoryProvider
    {
        private readonly IPurchaseHistoryProviderA getPurchaseHistoryCommandFromProviderA;
        private readonly IPurchaseHistoryProviderB getPurchaseHistoryCommandFromProviderB;
        private readonly IPurchaseHistoryProviderC getLegacyPurchasesOperationFromProviderC;

        public PurchaseHistoryProvider(
            IPurchaseHistoryProviderA getPurchaseHistoryCommandFromProviderA,
            IPurchaseHistoryProviderB getPurchaseHistoryCommandFromProviderB,
            IPurchaseHistoryProviderC getLegacyPurchasesOperationFromProviderC)
        {
            this.getPurchaseHistoryCommandFromProviderA = getPurchaseHistoryCommandFromProviderA;
            this.getPurchaseHistoryCommandFromProviderB = getPurchaseHistoryCommandFromProviderB;
            this.getLegacyPurchasesOperationFromProviderC = getLegacyPurchasesOperationFromProviderC;
        }


        public async Task<IEnumerable<PurchaseAggregate>> GetPurchases(CustomerId customerId,
            LegacyCustomerId legacyCustomerId)
        {
            var cancellationTokenSource = new CancellationTokenSource();

            var providerATask = getPurchaseHistoryCommandFromProviderA.GetPurchases(customerId, legacyCustomerId, cancellationTokenSource.Token);
            var providerBTask = getPurchaseHistoryCommandFromProviderB.GetPurchases(customerId, legacyCustomerId, cancellationTokenSource.Token);

            var providerParalellTasks = new[] {providerATask, providerBTask};
            var completedTasks = new List<Task<IEnumerable<PurchaseAggregate>>>();
            while (completedTasks.Count != providerParalellTasks.Length)
            {
                var completedTask = await Task.WhenAny(providerParalellTasks);

                if (!completedTask.IsFaulted)
                {
                    var result = completedTask.Result.ToList();

                    if (result.Any())
                    {
                        cancellationTokenSource.Cancel();
                        return result;
                    }
                }

                completedTasks.Add(completedTask);
            }

            var purchaseHistoryProviderCResult = await getLegacyPurchasesOperationFromProviderC.GetPurchases(customerId, legacyCustomerId,CancellationToken.None);

            return purchaseHistoryProviderCResult;
        }
    }
}
