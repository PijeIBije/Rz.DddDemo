using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Rz.DddDemo.Base.Domain.ValueObject;

namespace Rz.DddDemo.Customers.Domain
{
    public class LegacyCustomerId:StringValueObjectBase
    {
        public static readonly Regex Format = new Regex(@"^\d{8}$", RegexOptions.Compiled);

        public LegacyCustomerId(string value) : base(value, Format)
        {
        }

        public static implicit operator LegacyCustomerId(string value) => new LegacyCustomerId(value);
    }
}
