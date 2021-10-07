using System;
using System.ServiceModel;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using RabbitMQ.Client;
using Rz.DddDemo.Base.Infrastructure;
using Rz.DddDemo.Base.Infrastructure.MongoDb;
using Rz.DddDemo.Base.Presentation.WebApi;
using Rz.DddDemo.Customers.Infrastructure.PurchaseHistoryProvider.PurchaseHistoryProviderA.HttpClient;
using Rz.DddDemo.Customers.Presentation.WebApi.Configs;
using Rz.DddDemo.PurchaseHistoryProviderClient;
using Rz.DddDemo.PurchaseHistoryProviders.ProviderB.Protos;

namespace Rz.DddDemo.Customers.Presentation.WebApi.Di
{
    public static class InfrastructureDependenciesRegistrations
    {
        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services,
            IConfiguration configuration)
        {
            //repositories 

            services.AddSingleton<EntityCache>();
            services.AddSingleton<IncludesToProjectionBsonMapper>();

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

            services.AddSingleton<ConnectionFactory>(serviceProvider =>
            {
                var config = serviceProvider.GetService<RabbitMqConfig>();
                var connectionFactory = new ConnectionFactory
                {
                    UserName = config.UserName, Password = config.Password, HostName = config.HostName
                };
                return connectionFactory;
            });

            //Grpc

            services.ConfigureWithoutIOptions<PurchaseHistoryProviderBConfig>(
                configuration.GetSection(PurchaseHistoryProviderBConfig.AppSettingsKey));

            services
                .AddGrpcClient<CustomerDataServiceProto.CustomerDataServiceProtoClient, PurchaseHistoryProviderBConfig
                >();

            //Wcf

            services.ConfigureWithoutIOptions<PurchaseHistoryProviderCConfig>(
                configuration.GetSection(PurchaseHistoryProviderCConfig.AppSettingsKey));

            services.AddWcfClient<CustomerDataServiceClient, PurchaseHistoryProviderCConfig>();

            //HttpClient

            services.ConfigureWithoutIOptions<PurchaseHistoryProviderAConfig>(
                configuration.GetSection(PurchaseHistoryProviderAConfig.AppSettingsKey));

            services.AddHttpClient<PurchaseHistoryProviderAHttpClient, PurchaseHistoryProviderAConfig>();

            return services;
        }

        private static IServiceCollection AddGrpcClient<TGrpcClient,TGrpcConfig>(this IServiceCollection serviceCollection) 
            where TGrpcClient : class
            where TGrpcConfig : GrpcConfig
        {
            serviceCollection.AddGrpcClient<TGrpcClient>((serviceProvider,options) =>
            {
                var grpcConfig = (GrpcConfig)serviceProvider.GetService(typeof(TGrpcConfig))??throw new InvalidOperationException("Config not registered");
                options.Address = new Uri(grpcConfig.Address);
            });

            return serviceCollection;
        }

        private static IServiceCollection AddWcfClient<TChannel,TWcfConfig>(this IServiceCollection services)
            where TChannel:class
        where TWcfConfig:WcfConfig
        {
            services.AddScoped(serviceProvider =>
            {
                var config = serviceProvider.GetService<TWcfConfig>();

                var address = new EndpointAddress(config.Address);

                var basicHttpsBinding = new BasicHttpsBinding();

                var channelFactory = new ChannelFactory<TChannel>(basicHttpsBinding, address);

                return channelFactory;
            });

            return services;
        }

        private static IServiceCollection AddHttpClient<THttpClient, THttpClientConfig>(this IServiceCollection services)
        where THttpClientConfig:HttpClientConfig
        where THttpClient:class
        {
            services.AddHttpClient<THttpClient>((serviceProvider, httpClient) =>
            {
                var config = serviceProvider.GetService<HttpClientConfig>();

                httpClient.BaseAddress = new Uri(config.BaseAddress);
            });

            return services;
        }
    }
}
