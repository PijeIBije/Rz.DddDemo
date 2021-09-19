﻿using Microsoft.Extensions.DependencyInjection;
using Rz.DddDemo.Base.Presentation.WebApi.IncludesMapping;
using Rz.DddDemo.Base.Presentation.WebApi.Validation;
using Rz.DddDemo.Base.Presentation.WebApi.Validation.Mapping;
using Rz.DddDemo.Base.Presentation.WebApi.Validation.Mapping.Interfaces;

namespace Rz.DddDemo.Customers.Presentation.WebApi.Di
{
    public static class WebApiRegistrations
    {
        public static IServiceCollection AddWebApiExtensions(this IServiceCollection services)
        {
            services.AddSingleton<IncludesMapper>();
            services.AddSingleton<IExceptionMapper, ExceptionMapper>();
            services.AddSingleton<IExceptionMapping, DefaultExceptionMapping>();
            services.AddSingleton<ValidationErrorsDictionary>();

            return services;
        }
    }
}
