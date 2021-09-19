using System.Text.RegularExpressions;
using Rz.DddDemo.Base.Domain.ValueObject;

namespace Rz.DddDemo.Shipping.Domain.Order.Address.ValueObjects
{
    public class FirstName:StringValueObjectBase
    {
        public static readonly Regex Format = new Regex(@"\w{3,100}", RegexOptions.Compiled);

        public FirstName(string value) : base(value, Format)
        {

        }

        public static implicit operator FirstName(string value) => new FirstName(value);
    }
}
