using System.Threading.Tasks;
using MediatR;

namespace Rz.DddDemo.Base.Application.IntegrationEventHandling.Interfaces
{
    public interface IIntegrationEventHandler<in TIntegrationEvent>:IRequestHandler<TIntegrationEvent,NoResult> where TIntegrationEvent:IIntegrationEvent
    {
    }
}
