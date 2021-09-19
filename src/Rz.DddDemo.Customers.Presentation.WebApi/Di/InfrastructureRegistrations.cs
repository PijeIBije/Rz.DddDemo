using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using RabbitMQ.Client;
using Rz.DddDemo.Base.Infrastructure.MongoDb;
using Rz.DddDemo.Base.Presentation.WebApi;
using Rz.DddDemo.Customers.Presentation.WebApi.Configs;

namespace Rz.DddDemo.Customers.Presentation.WebApi.Di
{
    public static class InfrastructureRegistrations
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,IConfiguration configuration)
        {
            //MongoDb

            services.ConfigureWithoutIOptions<MongoDbConfig>(configuration.GetSection(MongoDbConfig.AppSettingsKey));

            services.AddSingleton<MongoSharedTransaction>();

            services.AddSingleton<MongoClient>(serviceProvider =>
            {
                var config = serviceProvider.GetService<MongoDbConfig>();
                var mongoClient = new MongoClient(config.ConnectionString);
                return mongoClient;
            });

            //RabbitMq

            services.ConfigureWithoutIOptions<RabbitMqConfig>(configuration.GetSection(RabbitMqConfig.AppSettingsKey));

            services.AddSingleton<RabbitMQ.Client.ConnectionFactory>(serviceProvider =>
            {
                var config = serviceProvider.GetService<RabbitMqConfig>();
                var connectionFactory = new ConnectionFactory
                {
                    UserName = config.UserName, Password = config.Password, HostName = config.HostName
                };
                return connectionFactory;
            });

            return services;
        }
    }
}
