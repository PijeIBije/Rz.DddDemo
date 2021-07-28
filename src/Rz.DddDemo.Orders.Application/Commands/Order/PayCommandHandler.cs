using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Rz.DddDemo.Base.Application.CommandHandling;
using Rz.DddDemo.Base.Application.DomainEventHandling;
using Rz.DddDemo.Base.Application.IntegrationEventHandling;
using Rz.DddDemo.Base.Application.TransactionHandling;
using Rz.DddDemo.Orders.Application.Interfaces;

namespace Rz.DddDemo.Orders.Application.Commands.Order
{
    public class PayCommandHandler:CommandHandlerBase<PayCommand>
    {
        private readonly IOrderRepository orderRepository;

        public PayCommandHandler(
            IOrderRepository orderRepository,
            DomainEventsHandler domainEventsHandler, 
            IntegrationEventsPublisher integrationEventsPublisher, 
            Transaction transaction) : base(domainEventsHandler, integrationEventsPublisher, transaction)
        {
            this.orderRepository = orderRepository;
        }

        protected override async Task HandleBody(PayCommand command)
        {
            var order = await orderRepository.GetById(command.OrderId);

            order.SetPaid();

            await orderRepository.Save(order);
        }
    }
}
