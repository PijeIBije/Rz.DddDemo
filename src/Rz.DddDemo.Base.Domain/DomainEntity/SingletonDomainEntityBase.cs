using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Rz.DddDemo.Base.Domain.DomainEntity.Interfaces;
using Rz.DddDemo.Base.Domain.DomainEvent.Interfaces;

namespace Rz.DddDemo.Base.Domain.DomainEntity
{
    public abstract class SingletonDomainEntityBase
    {
        public delegate void DomainEventHanlder<in TDomainEvent>(TDomainEvent domainEvent)
            where TDomainEvent : IDomainEvent;
    }
}
