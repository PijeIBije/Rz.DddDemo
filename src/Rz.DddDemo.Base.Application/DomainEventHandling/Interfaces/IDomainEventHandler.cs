using System.Threading.Tasks;
using Rz.DddDemo.Base.Domain.DomainEvent.Interfaces;

namespace Rz.DddDemo.Base.Application.DomainEventHandling.Interfaces
{
    public interface IDomainEventHandler<in TDomainEvent>:IDomainEventHandler where TDomainEvent : IDomainEvent
    {
        Task Handle(TDomainEvent domainEvent);
    }

    public interface IDomainEventHandler
    {

    }
}
