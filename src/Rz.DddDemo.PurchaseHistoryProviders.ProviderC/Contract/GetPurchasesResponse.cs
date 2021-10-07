using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Rz.DddDemo.PurchaseHistoryProviders.ProviderC.Contract
{
    [DataContract]
    public class GetPurchasesResponse
    {
        [DataMember]
        public List<Purchase> Purchases { get; set; }
    }
}