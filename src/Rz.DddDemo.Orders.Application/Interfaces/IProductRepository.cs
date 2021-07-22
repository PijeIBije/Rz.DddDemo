using System.Collections.Generic;
using System.Threading.Tasks;
using Rz.DddDemo.Orders.Domain.Product.ValueObjects;
using Rz.DddDemo.Orders.Domain.ProductAggregate;

namespace Rz.DddDemo.Orders.Application.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductAggregate>> GetByIds(IEnumerable<ProductId> productId);
    }
}
