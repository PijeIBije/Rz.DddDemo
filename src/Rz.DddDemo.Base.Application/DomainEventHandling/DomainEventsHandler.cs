using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rz.DddDemo.Base.Application.DomainEventHandling.Interfaces;
using Rz.DddDemo.Base.Domain.DomainEvent.Interfaces;

namespace Rz.DddDemo.Base.Application.DomainEventHandling
{
    public class DomainEventsHandler
    {
        private readonly Func<Type, IDomainEventHandler> domainEventHandlerProviderFunc;

        private readonly List<IDomainEvent> domainEvents = new List<IDomainEvent>();

        public DomainEventsHandler(Func<Type, IDomainEventHandler> domainEventHandlerProviderFunc)
        {
            this.domainEventHandlerProviderFunc = domainEventHandlerProviderFunc;
        }

        public void Register(IDomainEvent domainEvent)
        {
            domainEvents.Add(domainEvent);
        }

        public async Task HandleAll()
        {
            var currentDomainEvents = domainEvents.ToList();

            foreach (var currentDomainEvent in currentDomainEvents)
            {
                var domainEventType = currentDomainEvent.GetType();

                var domainEventHandler = domainEventHandlerProviderFunc(domainEventType);

                var handleMethod = domainEventHandler.GetType()
                    .GetMethod(nameof(IDomainEventHandler<IDomainEvent>.Handle), new[]{domainEventType});

                if (handleMethod != null)
                {
                    var handleTask = (Task)handleMethod.Invoke(domainEventHandler,new object[]{currentDomainEvent});
                    if(handleTask==null) throw new InvalidOperationException($"{nameof(IDomainEventHandler<IDomainEvent>.Handle)} must return a task.");
                    await handleTask;
                }
                else
                {
                    throw new InvalidOperationException(
                        $"No {nameof(IDomainEventHandler<IDomainEvent>.Handle)} accepting {domainEventType.FullName} on {domainEventHandler.GetType().FullName}");
                }
            }

            currentDomainEvents.Clear();
        }
    }
}
