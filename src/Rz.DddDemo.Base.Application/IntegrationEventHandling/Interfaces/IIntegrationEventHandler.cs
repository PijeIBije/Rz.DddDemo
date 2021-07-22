using System.Threading.Tasks;

namespace Rz.DddDemo.Base.Application.IntegrationEventHandling.Interfaces
{
    public interface IIntegrationEventHandler<in TIntegrationEvent>:IIntegrationEventHandler where TIntegrationEvent:IIntegrationEvent
    {
        Task<bool> Handle(TIntegrationEvent integrationEvent);
    }

    public interface IIntegrationEventHandler
    {
        Task<bool> Handle(IIntegrationEvent integrationEvent);
    }
}
