using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rz.DddDemo.Base.Application.DomainEventHandling;
using Rz.DddDemo.Base.Application.IntegrationEventHandling;
using Rz.DddDemo.Orders.Application.Interfaces;
using Rz.DddDemo.Orders.Domain.Customer;
using Rz.DddDemo.Orders.Domain.Order;

namespace Rz.DddDemo.Orders.Application.DomainEvents
{
    public class CustomerUpdatedDomainEventHandler:DomainEventHanlderBase<CustomerUpdatedDomainEvent>

    {
        private readonly IOrderRepository orderRepository;

        protected override async Task HandleBody(CustomerUpdatedDomainEvent domainEvent)
        {
            var customer = domainEvent.Id;
            
            var orders = (await orderRepository.GetNonShippedWithAddressNamesOrCustomerId(domainEvent.UpdatedAddressNames,customer.Id)).ToList();

            foreach (var order in orders)
            {
                order.OrderUpdated += RegisterDomianEvent;
                order.UpdateShippingAddress(new ShippingAddressValueObject(customer.FirstName,customer.LastName,customer.Addresses.Single(x=>x.Name == order.ShippingAddress.Name)));
            }

            await orderRepository.Save(orders);
        }

        public CustomerUpdatedDomainEventHandler(
            IOrderRepository orderRepository,
            DomainEventsHandler domainEventsHandler,
            IntegrationEventsPublisher integrationEventsPublisher) : 
            base(domainEventsHandler, integrationEventsPublisher)
        {
            this.orderRepository = orderRepository;
        }
    }
}
