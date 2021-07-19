using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Rz.DddDemo.Base.Domain.ValueObject
{
    public abstract class StringValueObjectBase:SingleValueObjectBase<string>
    {
        protected StringValueObjectBase(string value) : base(value)
        {
            //Guard.AgainstNullValue();
        }

        protected StringValueObjectBase(string value, IEnumerable<string> allowedValues):this(value)
        {

        }

        protected StringValueObjectBase(string value, int minLength, int maxLength):base(value)
        {

        }

        protected StringValueObjectBase(string value, Regex format):this(value)
        {

        }
    }
}
