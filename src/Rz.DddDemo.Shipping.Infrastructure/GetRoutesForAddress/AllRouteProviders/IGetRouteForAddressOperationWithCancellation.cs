using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Rz.DddDemo.Shipping.Domain.Order.Address;

namespace Rz.DddDemo.Shipping.Infrastructure.GetRoutesForAddress.AllRouteProviders
{
    interface IGetRouteForAddressOperationWithCancellation
    {
        Task<List<AddressValueObject>> GetRouteForAddress(AddressValueObject sourceAddress,
            CancellationToken cancellationToken);
    }
}
