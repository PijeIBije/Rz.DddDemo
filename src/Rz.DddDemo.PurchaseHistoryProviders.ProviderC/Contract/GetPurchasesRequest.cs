using System.Runtime.Serialization;

namespace Rz.DddDemo.PurchaseHistoryProviders.ProviderC.Contract
{
    [DataContract]
    public class GetPurchasesRequest
    {
        
        [DataMember]
        public string CustomerId { get; set; }

        [DataMember]
        public bool IncludeReturned { get; set; }
    }
}