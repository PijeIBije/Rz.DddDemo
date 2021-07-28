using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Rz.DddDemo.Base.Presentation.WebApi.RabbitMqHostedService.Interfaces;

namespace Rz.DddDemo.Base.Presentation.WebApi.RabbitMqHostedService
{

        public class RabbitMqSubscriberHostedService : IHostedService
        {
            private readonly string queueName;
            private readonly IEnumerable<IMessageHandler> messageHandlers;

            private readonly IConnection connection;
            private readonly IModel model;


            public RabbitMqSubscriberHostedService(
                string queueName,
                ConnectionFactory connectionFactory,
                IEnumerable<IMessageHandler> messageHandlers)
            {
                this.queueName = queueName;
                this.messageHandlers = messageHandlers;
                connection = connectionFactory.CreateConnection();
                model = connection.CreateModel();
            }

            public Task StartAsync(CancellationToken cancellationToken)
            {
                Register();
                return Task.CompletedTask;
            }

            // Registered consumer monitoring here
            public void Register()
            {
                model.QueueDeclare(queueName, true, false, false);

                foreach (var messageListener in messageHandlers)
                {
                    model.QueueBind(queueName, messageListener.ExchangeName,
                        messageListener.RoutingKey);
                }

                var consumer = new EventingBasicConsumer(model);

                consumer.Received += async (source, basicDeliverEventArgs) =>
                {
                    var mesageHandler = messageHandlers.SingleOrDefault(x =>
                        basicDeliverEventArgs.RoutingKey == x.RoutingKey
                        && basicDeliverEventArgs.Exchange == x.ExchangeName);

                    if (mesageHandler == null)
                        throw new Exception(
                            $"No valid message listener found for exchange {basicDeliverEventArgs.Exchange} and routing key {basicDeliverEventArgs.RoutingKey}");

                    var success = await mesageHandler.Handle(basicDeliverEventArgs.Body.ToArray());

                    if (success)
                    {
                        model.BasicAck(basicDeliverEventArgs.DeliveryTag, false);
                    }
                };

                model.BasicConsume(queue: queueName, consumer: consumer);
            }

            public void DeRegister()
            {
                connection.Close();
            }

            public Task StopAsync(CancellationToken cancellationToken)
            {
                connection.Close();
                return Task.CompletedTask;
            }
        }
    
}
