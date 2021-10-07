using System.Threading.Tasks;
using Rz.DddDemo.Base.Application.DomainEventHandling;
using Rz.DddDemo.Base.Application.IntegrationEventHandling;

namespace Rz.DddDemo.Reservations.Application.DomainEvents
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
