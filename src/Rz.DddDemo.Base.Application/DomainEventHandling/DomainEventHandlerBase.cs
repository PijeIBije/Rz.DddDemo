using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Rz.DddDemo.Base.Application.CommandHandling.Interfaces;
using Rz.DddDemo.Base.Application.DomainEventHandling.Interfaces;
using Rz.DddDemo.Base.Application.IntegrationEventHandling;
using Rz.DddDemo.Base.Application.IntegrationEventHandling.Interfaces;
using Rz.DddDemo.Base.Application.TransactionHandling;
using Rz.DddDemo.Base.Domain.DomainEvent.Interfaces;

namespace Rz.DddDemo.Base.Application.DomainEventHandling
{
    public abstract class DomainEventHanlderBase<TDomainEvent> : IDomainEventHandler<TDomainEvent,IDomainEventAdapter<TDomainEvent>> where TDomainEvent : IDomainEvent
    {
        private readonly DomainEventsHandler domainEventsHandler;
        private readonly IntegrationEventsPublisher integrationEventsPublisher;

        protected DomainEventHanlderBase(
            DomainEventsHandler domainEventsHandler,
            IntegrationEventsPublisher integrationEventsPublisher)
        {
            this.domainEventsHandler = domainEventsHandler;
            this.integrationEventsPublisher = integrationEventsPublisher;
        }

        public async Task Handle(IDomainEventAdapter<TDomainEvent> domainEventAdapter,CancellationToken cancellationToken)
        {
            if(cancellationToken.IsCancellationRequested) throw new OperationCanceledException();

            await HandleBody(domainEventAdapter.DomainEvent);
        }

        protected void RegisterIntegrationEvent(IIntegrationEvent integrationEvent)
        {
            integrationEventsPublisher.Register(integrationEvent);
        }

        protected void RegisterDomianEvent(IDomainEvent domainEvent)
        {
            domainEventsHandler.Register(domainEvent);
        }

        protected abstract Task HandleBody(TDomainEvent domainEvent);
        public async Task Handle(TDomainEvent domainEvent)
        {
            await HandleBody(domainEvent);
        }
    }
}
