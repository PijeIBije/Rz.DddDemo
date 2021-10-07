using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Rz.DddDemo.Base.Application.DomainEventHandling.Interfaces;
using Rz.DddDemo.Base.Domain.DomainEvent.Interfaces;

namespace Rz.DddDemo.Base.Application.DomainEventHandling
{
    public class DomainEventsHandler
    {
        private readonly IMediator mediator;
        private readonly List<IDomainEvent> domainEvents = new List<IDomainEvent>();

        public DomainEventsHandler(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public void Register(IDomainEvent domainEventAdapter)
        {
            domainEvents.Add(domainEventAdapter);
        }

        public async Task HandleAll()
        {
            foreach (var domainEvent in domainEvents)
            {
                var domainEventAdapterType = typeof(DomainEventAdapter<>).MakeGenericType(domainEvent.GetType());

                var domainEventAdapter = (IDomainEventAdapter)Activator.CreateInstance(domainEventAdapterType, domainEvent);

                await mediator.Publish(domainEventAdapter??throw new InvalidOperationException($"Could not wrap {domainEvent.GetType().FullName}"));
            }

            domainEvents.Clear();
        }
    }
}
