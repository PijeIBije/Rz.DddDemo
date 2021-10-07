using MediatR;

namespace Rz.DddDemo.Base.Application.IntegrationEventHandling.Interfaces
{
    public interface IIntegrationEventPublisher<in TIntegrationEvent>:IRequestHandler<TIntegrationEvent,NoResult> where TIntegrationEvent : IIntegrationEvent
    {
    }
}
