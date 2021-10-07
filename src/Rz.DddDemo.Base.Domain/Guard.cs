using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Rz.DddDemo.Base.Domain.Exceptions;
using Rz.DddDemo.Base.Domain.ValueObject.Exceptions;

namespace Rz.DddDemo.Base.Domain
{
    public static class Guard
    {
        public static void AgainstNullValues((object value, string parameterName)[] values,
            string message = "Value cannot be null")
        {
            foreach (var valueTuple in values)
            {
                AgainstNullValue(valueTuple.value,valueTuple.parameterName, message);
            }
        }

        public static void AgainstNullValue(object value, string parameterName, string message = "Value cannot be null")
        {
            if(value == null) throw new ArgumentNullException(parameterName,message);
        }

        public static void AgaintsNullOrEmptyValue(IEnumerable value, string parameterName,
            string message = "Value cannot be null or empty")
        {
            AgainstNullValue(value,parameterName,message);
            if (!value.GetEnumerator().MoveNext())
            {
                throw new ArgumentEmptyException(message,parameterName);
            }
        }
        public static void AgainstValueNotAllowed<TValue>(TValue value, string parameterName, IEnumerable<TValue> allowedValues, string message = "Value must be equal to one of the allowed values")
        {
            //if(!allowedValues.Contains(value)) throw new 
        }

        public static void AgainstValueNotInRange<TValueType>(
            string argumentName,
            TValueType value,
            TValueType min,
            TValueType max,
            bool includeMin = false,
            bool includeMax = false,
            string message = "Value not in range",
            Func<Exception, Exception> exceptionWrapper = null)
        where TValueType:IComparable
        {
            var minPassed = includeMin ? value.CompareTo(min) >= 0 : value.CompareTo(min) > 0;

            var maxPassed = includeMax ? value.CompareTo(max) <= 0 : value.CompareTo(max) < 0;

            if (minPassed && maxPassed) return;

            Exception exception = new ArgumentOutOfRangeException<TValueType>(
                argumentName,
                value,
                min,
                max,
                includeMin,
                includeMax,
                message);

            if (exceptionWrapper != null) exception = exceptionWrapper(exception);

            throw exception;
        }
    }
}
