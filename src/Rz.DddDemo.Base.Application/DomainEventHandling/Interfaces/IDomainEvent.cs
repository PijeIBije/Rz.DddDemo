using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using Rz.DddDemo.Base.Domain.DomainEvent.Interfaces;

namespace Rz.DddDemo.Base.Application.DomainEventHandling.Interfaces
{
    public interface IDomainEventAdapter<TDomainEvent>:IDomainEventAdapter
        where TDomainEvent:IDomainEvent
    {
        public new TDomainEvent DomainEvent { get; }
    }

    public interface IDomainEventAdapter:INotification
    {
        public IDomainEvent DomainEvent { get; }
    }
}
