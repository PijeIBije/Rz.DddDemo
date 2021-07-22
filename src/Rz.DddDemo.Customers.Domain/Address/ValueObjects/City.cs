using System.Text.RegularExpressions;
using Rz.DddDemo.Base.Domain.ValueObject;

namespace Rz.DddDemo.Customers.Domain.Address.ValueObjects
{
    public class City:StringValueObjectBase
    {
        public static readonly Regex Format = new Regex(@"\w{3,85}", RegexOptions.Compiled);

        public City(string value) : base(value, Format)
        {

        }

        public static implicit operator City(string value) => value != null ? new City(value) : null;
    }
}
