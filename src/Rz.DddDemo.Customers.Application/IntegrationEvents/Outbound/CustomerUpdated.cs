using System.Collections.Generic;
using Rz.DddDemo.Base.Application.IntegrationEventHandling.Interfaces;
using Rz.DddDemo.Customers.Domain;
using Rz.DddDemo.Customers.Domain.CustomerAggregate;
using Rz.DddDemo.Customers.Domain.CustomerAggregate.AddressAggregate.ValueObjects;

namespace Rz.DddDemo.Customers.Application.IntegrationEvents.Outbound
{
    public class CustomerUpdated:IIntegrationEvent
    {
        public Customer Customer { get; }
        public IEnumerable<AddressName> RemovedAddressesNames { get; }

        public CustomerUpdated(Customer customer, IEnumerable<AddressName> removedAddressesNames)
        {
            Customer = customer;
            RemovedAddressesNames = removedAddressesNames;
        }
    }
}
