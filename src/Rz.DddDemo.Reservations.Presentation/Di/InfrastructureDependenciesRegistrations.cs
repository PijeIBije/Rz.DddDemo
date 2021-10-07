using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Rz.DddDemo.Base.Presentation.WebApi;
using Rz.DddDemo.Reservations.Infrastructure.Schemas.Database.Sql;
using Rz.DddDemo.Reservations.Presentation.Configs;

namespace Rz.DddDemo.Reservations.Presentation.Di
{
    public static class InfrastructureDependenciesRegistrations
    {
        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services,
            IConfiguration configuration)
        {
            //repositories 


            //ef core

            services.ConfigureWithoutIOptions<RepertoryDbConfig>(configuration.GetSection(RepertoryDbConfig.AppSettingsKey));

            services.AddEfCoreSqlDbContextFactory<ReservationsDbContext, RepertoryDbConfig>();

            /*
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
            });*/

            return services;
        }

        private static IServiceCollection AddEfCoreSqlDbContextFactory<TDbContext, TSqlDbConfig>(this IServiceCollection services)
        where TDbContext:DbContext
        where TSqlDbConfig:SqlDbConfig
        {
            services.AddPooledDbContextFactory<TDbContext>((serviceProvider, dbContextOptions
            ) =>
            {
                var config = (SqlDbConfig)serviceProvider.GetService(typeof(TSqlDbConfig))??throw new InvalidOperationException("Config not registered.");

                dbContextOptions.UseSqlServer(config.ConnectionString);
            });

            return services;
        }
    }
}
