namespace Rz.DddDemo.Customers.Infrastructure.PurchaseHistoryProvider.PurchaseHistoryProviderA.HttpClient.Model
{
    public class ProductResource
    {
        public string Description { get; set; }

        public string ProductId { get; set; }

        public int Quantity { get; set; }

        public decimal PricePerItem { get; set; }
    }
}
