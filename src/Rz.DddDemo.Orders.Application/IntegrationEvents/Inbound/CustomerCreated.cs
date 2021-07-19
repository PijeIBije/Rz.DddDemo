using System;
using System.Collections.Generic;
using System.Text;
using Rz.DddDemo.Base.Application.IntegrationEventHandling.Interfaces;
using Rz.DddDemo.Orders.Domain.Customer.Address;
using Rz.DddDemo.Orders.Domain.Customer.ValueObjects;

namespace Rz.DddDemo.Orders.Application.IntegrationEvents.Inbound
{
    public class CustomerCreated:IIntegrationEvent
    {
        public CustomerId CustomerId { get; set; }

        public FirstName FirstName { get; set; }

        public LastName LastName { get; set; }

        public List<Address> Addresses { get; set; }
    }
}
