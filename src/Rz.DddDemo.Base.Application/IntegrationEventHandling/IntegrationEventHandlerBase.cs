using System.Threading.Tasks;
using Rz.DddDemo.Base.Application.DomainEventHandling;
using Rz.DddDemo.Base.Application.IntegrationEventHandling.Interfaces;
using Rz.DddDemo.Base.Application.TransactionHandling;
using Rz.DddDemo.Base.Domain.DomainEvent.Interfaces;

namespace Rz.DddDemo.Base.Application.IntegrationEventHandling
{
    public abstract class IntegrationEventHandlerBase<TIntegrationEvent>: IIntegrationEventHandler<TIntegrationEvent> where TIntegrationEvent:IIntegrationEvent
    {
        private readonly DomainEventsHandler domainEventsHandler;
        private readonly IntegrationEventsPublisher integrationEventsPublisher;
        private readonly Transaction transaction;

        protected void RegisterIntegrationEvent(IIntegrationEvent integrationEvent)
        {
            integrationEventsPublisher.Register(integrationEvent);
        }

        protected void RegisterDomianEvent(IDomainEvent domainEvent)
        {
            domainEventsHandler.Register(domainEvent);
        }

        protected IntegrationEventHandlerBase(
            DomainEventsHandler domainEventsHandler,
            IntegrationEventsPublisher integrationEventsPublisher,
            Transaction transaction)
        {
            this.domainEventsHandler = domainEventsHandler;
            this.integrationEventsPublisher = integrationEventsPublisher;
            this.transaction = transaction;
        }

        public async Task<bool> Handle(TIntegrationEvent integrationEvent)
        {
            transaction.Start();
            var result = await HandleBody(integrationEvent);
            await domainEventsHandler.HandleAll();
            await transaction.Commit();
            integrationEventsPublisher.PublishAll();
            return result;
        }

        protected abstract Task<bool> HandleBody(TIntegrationEvent customerUpdatedIntegrationEvent);
        public Task<bool> Handle(IIntegrationEvent integrationEvent)
        {
            return Handle((TIntegrationEvent) integrationEvent);
        }
    }
}
