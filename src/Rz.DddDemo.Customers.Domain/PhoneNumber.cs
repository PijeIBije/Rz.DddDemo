using System.Text.RegularExpressions;
using Rz.DddDemo.Base.Domain.ValueObject;

namespace Rz.DddDemo.Customers.Domain
{
    public class PhoneNumber:StringValueObjectBase
    {
        public static readonly Regex Format = new Regex(@"\+?\d{6,15}", RegexOptions.Compiled);

        public PhoneNumber(string value) : base(value, Format)
        {

        }

        public static implicit operator PhoneNumber(string value) => value != null ? new PhoneNumber(value) : null;
    }
}
