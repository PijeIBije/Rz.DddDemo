using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using RabbitMQ.Client;
using Rz.DddDemo.Base.Application;
using Rz.DddDemo.Base.Application.IntegrationEventHandling.Interfaces;

namespace Rz.DddDemo.Base.Infrastructure.RabbitMq
{
    public abstract class RabbitMqIntegrationEventPublisherBase<TIntegraionEvent,TIntegrationEventDto>:IIntegrationEventPublisher<TIntegraionEvent> where TIntegraionEvent:IIntegrationEvent
    {
        private readonly ConnectionFactory connectionFactory;
        private readonly RabbitMqIntegrationEventPublisherConfig config;


        protected RabbitMqIntegrationEventPublisherBase(
            ConnectionFactory connectionFactory, 
            RabbitMqIntegrationEventPublisherConfig config)
        {
            this.connectionFactory = connectionFactory;
            this.config = config;
        }

        public abstract TIntegrationEventDto ToIntegrationEventDto(TIntegraionEvent integrationEvent);

        public Task<NoResult> Handle(TIntegraionEvent integrationEvent, CancellationToken cancellationToken)
        {
            var connection = connectionFactory.CreateConnection();
            var model = connection.CreateModel();

            var integrationEventDto = ToIntegrationEventDto(integrationEvent);

            var bytes = JsonSerializer.SerializeToUtf8Bytes(integrationEventDto);

            model.BasicPublish(config.ExchangeName, config.RoutingKey, config.Mandatory, null, bytes);

            return Task.FromResult(NoResult.Instance);
        }
    }
}
