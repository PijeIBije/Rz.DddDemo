using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using RabbitMQ.Client;
using Rz.DddDemo.Base.Application.IntegrationEventHandling.Interfaces;

namespace Rz.DddDemo.Base.Infrastructure.RabbitMq
{
    public abstract class RabbitMqIntegrationEventPublisherBase<TIntegraionEvent,TIntegrationEventDto>:IIntegrationEventPublisher<TIntegraionEvent> where TIntegraionEvent:IIntegrationEvent
    {
        private readonly ConnectionFactory connectionFactory;
        private readonly string exchangeName;
        private readonly string routingKey;
        private readonly Dictionary<string, object> arguments;
        private readonly bool mandatory;

        protected RabbitMqIntegrationEventPublisherBase(ConnectionFactory connectionFactory, 
            string exchangeName, 
            string routingKey, 
            Dictionary<string,object> arguments,
            bool mandatory = false)
        {
            this.connectionFactory = connectionFactory;
            this.exchangeName = exchangeName;
            this.routingKey = routingKey;
            this.arguments = arguments;
            this.mandatory = mandatory;
        }


        public void Publish(TIntegraionEvent integrationEvent)
        {
            var connection = connectionFactory.CreateConnection();
            var model = connection.CreateModel();

            var integrationEventDto = ToIntegrationEventDto(integrationEvent);

            var bytes = JsonSerializer.SerializeToUtf8Bytes(integrationEventDto);

            model.BasicPublish(exchangeName, routingKey, mandatory, null, bytes);
        }

        public abstract TIntegrationEventDto ToIntegrationEventDto(TIntegraionEvent integrationEvent);
    }
}
