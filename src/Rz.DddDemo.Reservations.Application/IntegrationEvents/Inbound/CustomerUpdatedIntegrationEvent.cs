using System.Collections.Generic;
using Rz.DddDemo.Base.Application.IntegrationEventHandling.Interfaces;

namespace Rz.DddDemo.Reservations.Application.IntegrationEvents.Inbound
{
    public class CustomerUpdatedIntegrationEvent : IIntegrationEvent
    {
        public CustomerId CustomerId { get; set; }

        public FirstName FirstName { get; set; }

        public LastName LastName { get; set; }

        public List<AddressValueObject> Addresses { get; set; }
    }
}
