using System;
using System.Collections.Generic;
using System.Text;
using Rz.DddDemo.Base.Domain.DomainEntity;
using Rz.DddDemo.Customers.Domain.Purchase;

namespace Rz.DddDemo.Customers.Domain.CustomerDiscount
{
    public class CustomerDiscountAggregate:DomainEntityBase<CustomerDiscountId>
    {
        public event DomainEventHanlder<CustomerDiscountChangedDomainEvent> CustomerChanged;

        public Discount Discount { get; private set; }

        public CustomerId CustomerId { get;}

        public Price TotalPurchasePrice { get; private set; }

        public CustomerDiscountAggregate(CustomerId customerId,Price totalPurchasePrice) : this(new CustomerDiscountId(),customerId,totalPurchasePrice)
        {
        }

        public CustomerDiscountAggregate(CustomerDiscountId customerDiscountId, CustomerId customerId,Price totalPurchasePrice):base(customerDiscountId)
        {
            CustomerId = customerId;
            TotalPurchasePrice = totalPurchasePrice;
            Discount = Discount.Calculate(totalPurchasePrice);
        }

        public void UpdateTotalPurchasePrice(Price purchasePriceDelta)
        {
            TotalPurchasePrice += purchasePriceDelta;

            Discount = Discount.Calculate(TotalPurchasePrice);

            CustomerChanged?.Invoke(new CustomerDiscountChangedDomainEvent(this));
        }
    }
}
