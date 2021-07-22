using System.Text.Json;
using RabbitMQ.Client;
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


        public void Publish(TIntegraionEvent integrationEvent)
        {
            var connection = connectionFactory.CreateConnection();
            var model = connection.CreateModel();

            var integrationEventDto = ToIntegrationEventDto(integrationEvent);

            var bytes = JsonSerializer.SerializeToUtf8Bytes(integrationEventDto);

            model.BasicPublish(config.ExchangeName, config.RoutingKey, config.Mandatory, null, bytes);
        }

        public abstract TIntegrationEventDto ToIntegrationEventDto(TIntegraionEvent integrationEvent);
    }
}
