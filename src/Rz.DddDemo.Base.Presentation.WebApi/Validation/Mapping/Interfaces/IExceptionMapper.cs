using System;
using System.Collections.Generic;
using System.Text;
using Rz.DddDemo.Base.Presentation.WebApi.Validation.Errors;

namespace Rz.DddDemo.Base.Presentation.WebApi.Validation.Mapping.Interfaces
{
    public interface IExceptionMapper
    {
        IEnumerable<ValidationError> MapToValidationErrors(Exception exception);
    }
}
