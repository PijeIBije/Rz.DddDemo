using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Rz.DddDemo.Base.Presentation.WebApi.Validation.Errors;

namespace Rz.DddDemo.Base.Presentation.WebApi.Validation
{
    public static class ValidationMvcModelBuilderExtension
    {
        public static IMvcBuilder AddCustomInvalidModelStateRespone(this IMvcBuilder services)
        {
            services.ConfigureApiBehaviorOptions(options =>
            {
                options.InvalidModelStateResponseFactory = actionContext =>
                {
                    var validationErrorsDictionary =
                        actionContext.HttpContext.RequestServices.GetService(typeof(ValidationErrorsDictionary)) as
                            ValidationErrorsDictionary;

                    if (validationErrorsDictionary == null)
                        throw new Exception(
                            $"{nameof(ValidationErrorsDictionary)} service resolved but null, this is coding error.");

                    var result = new Dictionary<string, List<ValidationError>>();

                    var modelState = actionContext.ModelState;

                    foreach (var modelStateKey in modelState.Keys)
                    {
                        var modelStateEntry = modelState[modelStateKey];

                        foreach (var modelError in modelStateEntry.Errors)
                        {
                            var validationKey = validationErrorsDictionary.Keys.SingleOrDefault(x =>
                                x.CompareWithKeyAsMessage(modelError.ErrorMessage));

                            List<ValidationError> validationErrors;

                            if (validationKey != null)
                            {
                                validationErrors = validationErrorsDictionary[validationKey];
                                
                            }
                            else
                            {
                                validationErrors = new List<ValidationError>
                                {
                                    new ValidationError("JsonDeserializationError", modelError.ErrorMessage)
                                };
                            }

                            if(!result.ContainsKey(modelStateKey)) result[modelStateKey] = new List<ValidationError>();

                            result[modelStateKey].AddRange(validationErrors);
                        }
                    }

                    return new BadRequestObjectResult(result);
                };
            });

            return services;
        }
    }
}
