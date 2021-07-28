using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Rz.DddDemo.Shipping.Domain.Order.Address;

namespace Rz.DddDemo.Shipping.Application.Interfaces
{
    public interface IGetRouteForAddressOperation
    {
        public Task<List<AddressValueObject>> GetRouteForAddress(AddressValueObject sourceAddress);
    }
}
