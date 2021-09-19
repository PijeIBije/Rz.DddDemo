using Rz.DddDemo.Base.Application.IntegrationEventHandling.Interfaces;
using Rz.DddDemo.Orders.Domain.Customer;

namespace Rz.DddDemo.Orders.Application.IntegrationEvents.Outbound
{
    public class CustomerDataRequestedIntegrationEvent:IIntegrationEvent
    {
        public CustomerId CustomerId { get; }

        public CustomerDataRequestedIntegrationEvent(CustomerId customerId)
        {
            CustomerId = customerId;
        }
    }
}
