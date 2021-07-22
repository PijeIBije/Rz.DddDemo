using System.Text.RegularExpressions;
using Rz.DddDemo.Base.Domain.ValueObject;

namespace Rz.DddDemo.Customers.Domain.Address.ValueObjects
{
    public class AddressLine:StringValueObjectBase
    {
        public static readonly Regex Format = new Regex(@"\S{0,100}", RegexOptions.Compiled);

        public AddressLine(string value) : base(value, Format)
        {

        }

        public static implicit operator AddressLine(string value) => value != null ? new AddressLine(value) : null;
    }
}
