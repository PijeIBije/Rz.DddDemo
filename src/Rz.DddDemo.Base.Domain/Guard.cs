using System;
using System.Collections.Generic;

namespace Rz.DddDemo.Base.Domain
{
    public static class Guard
    {
        public static void AgainstNullValue(object value, string parameterName, string message = "Value cannot be null.")
        {
            if(value == null) throw new ArgumentNullException(parameterName,message);
        }

        public static void AgainstValueNotAllowed<TValue>(TValue value, string parameterName, IEnumerable<TValue> allowedValues, string message = "Value must be equal to one of the allowed values")
        {
            //if(!allowedValues.Contains(value)) throw new 
        }
    }
}
