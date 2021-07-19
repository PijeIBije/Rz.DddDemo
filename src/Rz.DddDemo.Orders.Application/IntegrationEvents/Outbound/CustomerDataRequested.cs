using System;
using System.Collections.Generic;
using System.Text;
using Rz.DddDemo.Base.Application.IntegrationEventHandling.Interfaces;
using Rz.DddDemo.Orders.Domain.Customer.ValueObjects;

namespace Rz.DddDemo.Orders.Application.IntegrationEvents.Outbound
{
    public class CustomerDataRequested:IIntegrationEvent
    {
        public CustomerId CustomerId { get; }

        public CustomerDataRequested(CustomerId customerId)
        {
            CustomerId = customerId;
        }
    }
}
