using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Rz.DddDemo.Base.Application.DomainEventHandling;
using Rz.DddDemo.Base.Application.DomainEventHandling.Interfaces;
using Rz.DddDemo.Base.Application.IntegrationEventHandling;
using Rz.DddDemo.Orders.Domain.AutoCancellationParameters.DomainEvents;

namespace Rz.DddDemo.Orders.Application.DomainEvents
{
    public class AutoCancellationEvaluationHourChangedDomainEventHandler:DomainEventHanlderBase<AutoCancellationEvaluationHourChangedDomainEvent>
    {
        protected override Task HandleBody(AutoCancellationEvaluationHourChangedDomainEvent domainEvent)
        {

            return Task.CompletedTask;
        }

        public AutoCancellationEvaluationHourChangedDomainEventHandler(
            DomainEventsHandler domainEventsHandler, 
            IntegrationEventsPublisher integrationEventsPublisher) : 
            base(domainEventsHandler, integrationEventsPublisher)
        {
        }
    }
}
