using System.Text.RegularExpressions;
using Rz.DddDemo.Base.Domain.ValueObject;

namespace Rz.DddDemo.Customers.Domain
{
    public class Name:StringValueObjectBase
    {
        public static readonly Regex Format = new Regex(@"\w{3,100}", RegexOptions.Compiled);

        public Name(string value) : base(value, Format)
        {

        }

        public static implicit operator Name(string value) => new Name(value);
    }
}
