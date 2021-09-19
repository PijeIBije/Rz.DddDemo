﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Rz.DddDemo.Orders.Domain.Product;

namespace Rz.DddDemo.Orders.Application.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductAggregate>> GetByIds(IEnumerable<ProductId> productId);
    }
}
