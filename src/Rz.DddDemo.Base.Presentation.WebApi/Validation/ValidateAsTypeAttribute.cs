using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Rz.DddDemo.Base.Mapping.Interface;

namespace Rz.DddDemo.Base.Presentation.WebApi.Validation
{
    public class ValidateAsTypeAttribute:ValidationAttribute
    {
        public Type Type { get; }

        public ValidateAsTypeAttribute(Type type)
        {
            Type = type;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(value == null) return ValidationResult.Success;

            var mapper = (IMapper)validationContext.GetService(typeof(IMapper));

            if(mapper == null) throw new Exception($"{nameof(IMapper)}is resolved but null");

            try
            {
                mapper.Map(value, Type, out _);
            }
            catch (Exception exception)
            {
                return new ValidationResult(exception.Message);
            }

            return ValidationResult.Success;
        }
    }
}
