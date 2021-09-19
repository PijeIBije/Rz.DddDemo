using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Rz.DddDemo.Base.Domain.ValueObject;

namespace Rz.DddDemo.Customers.Domain.Address.ValueObjects
{
    public class PostalCode:StringValueObjectBase
    {
        public static readonly Regex Regex = new Regex(@"(?i)^[a-z0-9][a-z0-9\- ]{0,10}[a-z0-9]$",RegexOptions.Compiled);
        
        public PostalCode(string value) : base(value, Regex)
        {
        }

        public static implicit operator PostalCode(string value) => new PostalCode(value);
    }
}
