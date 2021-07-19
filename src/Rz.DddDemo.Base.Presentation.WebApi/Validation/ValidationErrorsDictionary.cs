using System;
using System.Collections.Generic;
using System.Text;
using Rz.DddDemo.Base.Presentation.WebApi.Validation.Errors;

namespace Rz.DddDemo.Base.Presentation.WebApi.Validation
{
    public class ValidationErrorsDictionary:Dictionary<ValidationErrorKey,List<ValidationError>>
    {
        public void Add(ValidationErrorKey memberName, ValidationError validationError)
        {
            Add(memberName,new []{validationError});
        }


        public void Add(ValidationErrorKey memberName, IEnumerable<ValidationError> validationErrors)
        {
            if (!TryGetValue(memberName, out var requestErrors))
            {
                requestErrors = new List<ValidationError>();

                Add(memberName, requestErrors);
            }

            requestErrors.AddRange(validationErrors);
        }
    }
}
