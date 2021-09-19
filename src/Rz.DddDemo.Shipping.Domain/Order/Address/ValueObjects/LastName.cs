using System.Text.RegularExpressions;
using Rz.DddDemo.Base.Domain.ValueObject;

namespace Rz.DddDemo.Shipping.Domain.Order.Address.ValueObjects
{
    public class LastName:StringValueObjectBase
    {
        public static readonly Regex Format = new Regex(@"\w{3,100}", RegexOptions.Compiled);

        public LastName(string value) : base(value, Format)
        {

        }


        public static implicit operator LastName(string value) => new LastName(value);
    }
}
