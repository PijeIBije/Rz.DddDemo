using System.Threading;
using System.Threading.Tasks;
using Rz.DddDemo.Base.Application.CommandHandling.Interfaces;
using Rz.DddDemo.Base.Application.DomainEventHandling;
using Rz.DddDemo.Base.Application.DomainEventHandling.Interfaces;
using Rz.DddDemo.Base.Application.IntegrationEventHandling;
using Rz.DddDemo.Base.Application.IntegrationEventHandling.Interfaces;
using Rz.DddDemo.Base.Application.TransactionHandling;
using Rz.DddDemo.Base.Domain.DomainEvent.Interfaces;

namespace Rz.DddDemo.Base.Application.CommandHandling
{
    public abstract class CommandHandlerBase<TCommand,TResult>:ICommandHandler<TCommand,TResult> 
        where TCommand:ICommand<TResult>
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

        public virtual async Task<TResult> Handle(TCommand command,CancellationToken _)
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

        protected void RegisterDomianEvent(IDomainEvent domainEventAdapter)
        {
            domainEventsHandler.Register(domainEventAdapter);
        }

        protected abstract Task<TResult> HandleBody(TCommand command);
    }

    public abstract class CommandHandlerBase<TCommand>:CommandHandlerBase<TCommand,NoResult> where TCommand : ICommand<NoResult>
    {
        protected CommandHandlerBase(
            DomainEventsHandler domainEventsHandler, 
            IntegrationEventsPublisher integrationEventsPublisher,
            Transaction transaction):base(
            domainEventsHandler, integrationEventsPublisher, transaction)
        {
        }

        protected NoResult NoResult => NoResult.Instance;
    }

}
