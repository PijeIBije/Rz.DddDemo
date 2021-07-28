using Rz.DddDemo.Base.Domain.DomainEntity;
using Rz.DddDemo.Orders.Domain.Product.ValueObjects;

namespace Rz.DddDemo.Orders.Domain.Product
{
    public class ProductAggregate:DomainEntityBase<ProductId>
    {
        public string Name { get; }
        public decimal Price { get; }
        
        public ProductAggregate(ProductId id, string name, decimal price) : base(id)
        {
            Name = name;
            Price = price;
        }
    }
}
