using System.Runtime.Serialization.Formatters;
using System.Text.RegularExpressions;
using Rz.DddDemo.Base.Domain.ValueObject;

namespace Rz.DddDemo.Customers.Domain.CustomerAggregate.AddressAggregate.ValueObjects
{
    public class AddressName:StringValueObjectBase
    {
        public static readonly Regex Format = new Regex(@"\w{3,100}",RegexOptions.Compiled);

        public AddressName(string value) : base(value, Format)
        {

        }

        public static implicit operator AddressName(string value) => value != null ? new AddressName(value) : null;
    }
}
