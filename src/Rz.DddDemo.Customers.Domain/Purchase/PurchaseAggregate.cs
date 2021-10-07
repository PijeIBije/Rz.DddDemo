using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rz.DddDemo.Base.Domain;
using Rz.DddDemo.Base.Domain.DomainEntity;

namespace Rz.DddDemo.Customers.Domain.Purchase
{
    public class PurchaseAggregate:DomainEntityBase<PurchaseId>
    {
        public Price TotalPrice => PurchaseItems.Sum(x => x.TotalPrice);

        public bool Cancelled { get; set; }

        public CustomerId CustomerId { get; }

        public DateTime PurchaseDate { get; }

        public IReadOnlyList<PurchaseItem> PurchaseItems { get; }


        public PurchaseAggregate(
            PurchaseId purchaseId,
            CustomerId customerId,
            DateTime purchaseDate,
            IReadOnlyList<PurchaseItem> purchaseItems):base(purchaseId)
        {
            Guard.AgaintsNullOrEmptyValue(purchaseItems,nameof(purchaseItems));
            Guard.AgainstNullValue(customerId, nameof(customerId));

            CustomerId = customerId;
            PurchaseDate = purchaseDate;
            PurchaseItems = purchaseItems;
            Cancelled = false;
        }
    }
}
