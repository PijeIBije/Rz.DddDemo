using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Rz.DddDemo.Base.Application.DomainEventHandling;
using Rz.DddDemo.Base.Application.DomainTaskHandling.Interfaces;
using Rz.DddDemo.Base.Application.IntegrationEventHandling;
using Rz.DddDemo.Base.Application.IntegrationEventHandling.Interfaces;
using Rz.DddDemo.Base.Application.TransactionHandling;
using Rz.DddDemo.Base.Domain.DomainEvent.Interfaces;

namespace Rz.DddDemo.Base.Application.DomainTaskHandling
{
    public abstract class DomainTaskHandlerBase<TCommand> : IDomainTask where TCommand : IDomainTask
    {
        private readonly DomainEventsHandler domainEventsHandler;
        private readonly IntegrationEventsPublisher integrationEventsPublisher;
        private readonly Transaction transaction;

        protected DomainTaskHandlerBase(
            DomainEventsHandler domainEventsHandler,
            IntegrationEventsPublisher integrationEventsPublisher,
            Transaction transaction)
        {
            this.domainEventsHandler = domainEventsHandler;
            this.integrationEventsPublisher = integrationEventsPublisher;
            this.transaction = transaction;
        }

        public async Task Handle(TCommand command)
        {
            transaction.Start();
            await HandleBody(command);
            await domainEventsHandler.HandleAll();
            await transaction.Commit();
            integrationEventsPublisher.PublishAll();
        }

        protected void RegisterIntegrationEvent(IIntegrationEvent integrationEvent)
        {
            integrationEventsPublisher.Register(integrationEvent);
        }

        protected void RegisterDomianEvent(IDomainEvent domainEvent)
        {
            domainEventsHandler.Register(domainEvent);
        }

        protected abstract Task HandleBody(TCommand command);
    }
}
