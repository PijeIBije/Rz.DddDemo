using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Rz.DddDemo.Shipping.Application.Interfaces;
using Rz.DddDemo.Shipping.Domain.Order.Address;
using Rz.DddDemo.Shipping.Infrastructure.GetRoutesForAddress.AllRouteProviders;

namespace Rz.DddDemo.Shipping.Infrastructure.GetRoutesForAddress.RouteProviderB.Mock
{
    public class GetRouteForAddressOperation : IGetRouteForAddressOperation, IGetRouteForAddressOperationWithCancellation
    {
        public async Task<List<AddressValueObject>> GetRouteForAddress(AddressValueObject sourceAddress)
        {
            return await GetRouteForAddress(sourceAddress, CancellationToken.None);
        }

        public async Task<List<AddressValueObject>> GetRouteForAddress(AddressValueObject sourceAddress,
            CancellationToken cancellationToken)
        {

        }
    }
}
