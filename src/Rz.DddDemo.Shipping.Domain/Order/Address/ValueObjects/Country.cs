using System.Text.RegularExpressions;
using Rz.DddDemo.Base.Domain.ValueObject;

namespace Rz.DddDemo.Shipping.Domain.Order.Address.ValueObjects
{
    public class Country:StringValueObjectBase
    {
        public static readonly Regex Format = new Regex(@"\w{3,56}", RegexOptions.Compiled);

        public Country(string value) : base(value, Format)
        {

        }

        public static implicit operator Country(string value) => value != null ? new Country(value) : null;
    }
}
