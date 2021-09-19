using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Rz.DddDemo.Base.Application.CommandHandling;
using Rz.DddDemo.Base.Application.DomainEventHandling;
using Rz.DddDemo.Base.Application.IntegrationEventHandling;
using Rz.DddDemo.Base.Application.TransactionHandling;

namespace Rz.DddDemo.Shipping.Application.Commands
{
    public class ScheduleShipmentCommandHandler:CommandHandlerBase<ScheduleShipmentCommand>
    {
        public ScheduleShipmentCommandHandler(DomainEventsHandler domainEventsHandler, IntegrationEventsPublisher integrationEventsPublisher, Transaction transaction) : base(domainEventsHandler, integrationEventsPublisher, transaction)
        {
        }

        protected override Task HandleBody(ScheduleShipmentCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
