using System.Collections.Generic;
using Rz.DddDemo.Base.Application.IntegrationEventHandling.Interfaces;
using Rz.DddDemo.Orders.Domain.Customer;
using Rz.DddDemo.Orders.Domain.Customer.Address;
using Rz.DddDemo.Orders.Domain.Customer.Address.ValueObjects;

namespace Rz.DddDemo.Orders.Application.IntegrationEvents.Inbound
{
    public class CustomerUpdatedIntegrationEvent : IIntegrationEvent
    {
        public CustomerId CustomerId { get; set; }

        public FirstName FirstName { get; set; }

        public LastName LastName { get; set; }

        public List<AddressValueObject> Addresses { get; set; }
    }
}
