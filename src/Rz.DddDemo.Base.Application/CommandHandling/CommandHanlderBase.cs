using System.Threading.Tasks;
using Rz.DddDemo.Base.Application.CommandHandling.Interfaces;
using Rz.DddDemo.Base.Application.DomainEventHandling;
using Rz.DddDemo.Base.Application.IntegrationEventHandling;
using Rz.DddDemo.Base.Application.IntegrationEventHandling.Interfaces;
using Rz.DddDemo.Base.Application.TransactionHandling;
using Rz.DddDemo.Base.Domain.DomainEvent.Interfaces;

namespace Rz.DddDemo.Base.Application.CommandHandling
{
    public abstract class CommandHandlerBase<TCommand,TResult>:ICommandHandler<TCommand,TResult> where TCommand:ICommand
    {
        private readonly DomainEventsHandler domainEventsHandler;
        private readonly IntegrationEventsPublisher integrationEventsPublisher;
        private readonly Transaction transaction;

        protected CommandHandlerBase(
            DomainEventsHandler domainEventsHandler,
            IntegrationEventsPublisher integrationEventsPublisher, Transaction transaction)
        {
            this.domainEventsHandler = domainEventsHandler;
            this.integrationEventsPublisher = integrationEventsPublisher;
            this.transaction = transaction;
        }

        public async Task<TResult> Handle(TCommand command)
        {
            transaction.Start();
            var result = await HandleBody(command);
            await domainEventsHandler.HandleAll();
            await transaction.Commit();
            integrationEventsPublisher.PublishAll();
            return result;
        }

        protected void RegisterIntegrationEvent(IIntegrationEvent integrationEvent)
        {
            integrationEventsPublisher.Register(integrationEvent);
        }

        protected void RegisterDomianEvent(IDomainEvent domainEvent)
        {
            domainEventsHandler.Register(domainEvent);
        }

        protected abstract Task<TResult> HandleBody(TCommand command);
    }

    public abstract class CommandHandlerBase<TCommand>:ICommandHandler<TCommand> where TCommand : ICommand
    {
        private readonly DomainEventsHandler domainEventsHandler;
        private readonly IntegrationEventsPublisher integrationEventsPublisher;
        private readonly Transaction transaction;

        protected CommandHandlerBase(
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
