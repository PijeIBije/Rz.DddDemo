using System;
using System.Collections.Generic;
using System.Linq;
using Rz.DddDemo.Base.Presentation.WebApi.Validation.Errors;
using Rz.DddDemo.Base.Presentation.WebApi.Validation.Mapping.Interfaces;

namespace Rz.DddDemo.Base.Presentation.WebApi.Validation.Mapping
{
    public class ExceptionMapper:IExceptionMapper
    {
        private readonly IEnumerable<IExceptionMapping> exceptionMappings;

        public ExceptionMapper(IEnumerable<IExceptionMapping> exceptionMappings)
        {
            this.exceptionMappings = exceptionMappings;
        }

        public IEnumerable<ValidationError> MapToValidationErrors(Exception exception)
        {
            IEnumerable<ValidationError> result = null;

            if (!exceptionMappings.Any(x => x.TryMapToRequestErrors(exception, out result)))
            {
                throw new Exception($"Cannot map exception {exception}");
            }

            return result;
        }
    }
}
