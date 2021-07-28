using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Rz.DddDemo.Orders.Application.Interfaces;
using Rz.DddDemo.Orders.Domain.Product;
using Rz.DddDemo.Orders.Domain.Product.ValueObjects;

namespace Rz.DddDemo.Orders.Infrastructure.ProductRepository.Mock
{
    public class ProductRepository:IProductRepository
    {
        public static ProductAggregate MockedProduct1 = new ProductAggregate(
            Guid.Parse("f25bbbed-fee4-4c82-a8ff-23d7cfdf4ecf"),
            "Product1",
            10m);

        public static ProductAggregate MockedProduct2 = new ProductAggregate(
            Guid.Parse("9b293075-544c-45c3-8f5b-d9280b892a03"),
            "Product2",
            20m);

        public static ProductAggregate MockedProduct3 = new ProductAggregate(
            Guid.Parse("73a87cd2-84dd-4243-b0bf-0f21a4d314a0"),
            "Product3",
            30m);

        public Task<IEnumerable<ProductAggregate>> GetByIds(IEnumerable<ProductId> productId)
        {
            var result = new[]
            {
                MockedProduct1,
                MockedProduct2,
                MockedProduct3
            };

            return Task.FromResult((IEnumerable<ProductAggregate>)result);
        }
    }
}
