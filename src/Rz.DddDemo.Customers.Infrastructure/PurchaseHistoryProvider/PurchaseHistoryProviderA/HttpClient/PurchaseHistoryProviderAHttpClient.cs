using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Rz.DddDemo.Customers.Infrastructure.PurchaseHistoryProvider.PurchaseHistoryProviderA.HttpClient.Model;

namespace Rz.DddDemo.Customers.Infrastructure.PurchaseHistoryProvider.PurchaseHistoryProviderA.HttpClient
{
    public class PurchaseHistoryProviderAHttpClient
    {
        private const string PurchasesPath = @"Customer/{id}/Purchase";

        private const string IdParameterName = "id";

        private readonly System.Net.Http.HttpClient httpClient;

        public PurchaseHistoryProviderAHttpClient(System.Net.Http.HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<PurchaseResource>> GetPurchases(string customerId,
            CancellationToken cancellationToken)
        {
            var query = HttpUtility.ParseQueryString(PurchasesPath);

            query.Set(IdParameterName, customerId);

            var response = await httpClient.GetAsync(new Uri(query.ToString()!), cancellationToken);

            if(response.IsSuccessStatusCode) throw new Exception();

            var purchases = JsonSerializer.Deserialize<IEnumerable<PurchaseResource>>(await response.Content.ReadAsByteArrayAsync(cancellationToken));

            return purchases;
        }
    }
}
