using System;
using System.Collections.Generic;
using System.Text;
using Rz.DddDemo.Base.Domain.DomainEvent.Interfaces;

namespace Rz.DddDemo.Base.Domain.DomainEvent
{
    public abstract class DomainEventBase<TSource>:IDomainEvent
    {
        public TSource Source { get; }
        protected DomainEventBase(TSource source)
        {
            Source = source;
        }
    }
}
