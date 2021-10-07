using Rz.DddDemo.Base.Domain.ValueObject;

namespace Rz.DddDemo.Customers.Domain.Purchase
{
    public class ProductName:StringValueObjectBase
    {
        public ProductName(string value) : base(value, 1, 200)
        {
        }

        public static implicit operator ProductName(string value) => new ProductName(value);
    }
}
