using System;
using System.Collections.Generic;
using System.Text;
using Rz.DddDemo.Base.Domain;
using Rz.DddDemo.Base.Domain.DomainEntity;

namespace Rz.DddDemo.Customers.Domain.Purchase
{
    public class PurchaseItem
    {
        public ProductName ProductName { get; }
        public Quantity Quantity { get; }
        public Price ProductPrice { get; }

        public Price TotalPrice => ProductPrice * Quantity;

        public PurchaseItem(
            ProductName productName, 
            Quantity quantity,
            Price productPrice)
        {
            Guard.AgainstNullValues(new (object value, string name)[]
            {
                (productName,nameof(productName)),
                (quantity, nameof(quantity)),
                (productPrice,nameof(productPrice))
            });

            ProductName = productName;
            Quantity = quantity;
            ProductPrice = productPrice;
        }
    }
}
