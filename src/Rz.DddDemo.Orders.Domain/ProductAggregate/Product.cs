using System;
using System.Collections.Generic;
using System.Text;
using Rz.DddDemo.Base.Domain.DomainEntity;
using Rz.DddDemo.Orders.Domain.ProductAggregate.ValueObjects;

namespace Rz.DddDemo.Orders.Domain.ProductAggregate
{
    public class Product:DomainEntityBase<ProductId>
    {
        public string Name { get; }
        public decimal Price { get; }
        
        public Product(ProductId id, string name, decimal price) : base(id)
        {
            Name = name;
            Price = price;
        }
    }
}
