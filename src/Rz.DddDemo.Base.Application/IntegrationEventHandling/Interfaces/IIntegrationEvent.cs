using MediatR;

namespace Rz.DddDemo.Base.Application.IntegrationEventHandling.Interfaces
{
    public interface IIntegrationEvent:IRequest<NoResult>
    {

    }
}
