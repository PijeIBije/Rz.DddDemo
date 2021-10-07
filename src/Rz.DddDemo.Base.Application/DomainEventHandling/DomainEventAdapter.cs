using System;
using System.Collections.Generic;
using System.Text;
using Rz.DddDemo.Base.Application.DomainEventHandling.Interfaces;
using Rz.DddDemo.Base.Domain.DomainEvent.Interfaces;

namespace Rz.DddDemo.Base.Application.DomainEventHandling
{
    public class DomainEventAdapter<TDomainEvent>:IDomainEventAdapter<TDomainEvent> where TDomainEvent:IDomainEvent
    {
        public TDomainEvent DomainEvent { get; }

        public DomainEventAdapter(TDomainEvent domainEvent)
        {
         DomainEvent = domainEvent;   
        }

        IDomainEvent IDomainEventAdapter.DomainEvent => DomainEvent;
    }
}
