using System.Runtime.Serialization;

namespace Rz.DddDemo.PurchaseHistoryProviders.ProviderC.Contract
{
    [DataContract]
    public class Item
    {
        [DataMember]
        public int Count { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public decimal Price { get; set; }
    }
}