using Microsoft.Extensions.DependencyInjection;
using Rz.DddDemo.Base.Mapping;
using Rz.DddDemo.Base.Mapping.DefaultMappings;
using Rz.DddDemo.Base.Mapping.DomainObjects;
using Rz.DddDemo.Base.Mapping.Interface;
using Rz.DddDemo.Reservations.Infrastructure.PerformanceRepository.EfCoreSql;

namespace Rz.DddDemo.Reservations.Presentation.Di
{
    public static class MapperRegistrations
    {
        public static IServiceCollection AddMapper(this IServiceCollection services)
        {
            services.AddSingleton<IMapper,Mapper>();
            services.AddSingleton<IValueMapping, ObjectToSingleValueObject>();
            services.AddSingleton<IValueMapping, SingleValueToObjectMapping>();
            services.AddSingleton<IValueMapping, DictionaryMapping>();
            services.AddSingleton<IValueMapping, ListMapping>();
            services.AddSingleton<IValueMapping, ClassMapping>();
            services.AddSingleton<IValueMapping, ValueTypeMapping>();

            //specialized
            services.AddSingleton<IValueMapping, SeatDtoToSeatEntityValueMapper>();

            return services;
        }
    }
}
