using System;
using System.Collections.Generic;
using System.Text;
using Rz.DddDemo.Base.Application.IntegrationEventHandling.Interfaces;
using Rz.DddDemo.Base.Domain;
using Rz.DddDemo.Customers.Domain.CustomerDiscount;

namespace Rz.DddDemo.Customers.Application.IntegrationEvents.Outbound
{
    public class CustomerDiscountUpdatedIntegrationEvent:IIntegrationEvent
    {
        public CustomerDiscountAggregate CustomerDiscount { get; }

        public CustomerDiscountUpdatedIntegrationEvent(CustomerDiscountAggregate customerDiscount)
        {
            Guard.AgainstNullValue(customerDiscount,nameof(customerDiscount));
            CustomerDiscount = customerDiscount;
        }
    }
}
