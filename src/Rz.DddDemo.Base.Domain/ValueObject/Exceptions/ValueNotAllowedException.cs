using System;
using System.Collections.Generic;

namespace Rz.DddDemo.Base.Domain.ValueObject.Exceptions
{
    public class ValueNotAllowedException<TValue>:ArgumentException
    {
        public IEnumerable<TValue> AllowedValues { get; }

        public ValueNotAllowedException(string parameterName, IEnumerable<TValue> allowedValues, string message=null):base(message,parameterName)
        {
            AllowedValues = allowedValues;
        }
    }
}
