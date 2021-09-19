using Rz.DddDemo.Base.Domain.DomainEvent.Interfaces;

namespace Rz.DddDemo.Base.Domain.DomainEvent
{
    public abstract class DomainEventBase<TSource>:IDomainEvent
    {
        public TSource Id { get; }
        protected DomainEventBase(TSource id)
        {
            Id = id;
        }
    }
}
