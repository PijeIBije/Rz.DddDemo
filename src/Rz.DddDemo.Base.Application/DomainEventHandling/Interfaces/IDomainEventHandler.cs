using System.Threading.Tasks;
using MediatR;
using Rz.DddDemo.Base.Domain.DomainEvent.Interfaces;

namespace Rz.DddDemo.Base.Application.DomainEventHandling.Interfaces
{
    public interface IDomainEventHandler<TDomainEvent, TDomainEventAdapter>:INotificationHandler<TDomainEventAdapter> 
        where TDomainEvent : IDomainEvent
        where TDomainEventAdapter:IDomainEventAdapter<TDomainEvent>
    {
        Task Handle(TDomainEvent domainEvent);
    }
}
