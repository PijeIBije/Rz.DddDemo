using System.Collections.Generic;
using System.Threading.Tasks;
using Rz.DddDemo.Shipping.Application.Interfaces;
using Rz.DddDemo.Shipping.Domain.Order.Address;

namespace Rz.DddDemo.Shipping.Infrastructure.GetRoutesForAddress.RouteProviderC.WcfClient
{
    public class GetRouteForAddressOperation : IGetRouteForAddressOperation
    {
        public async Task<List<AddressValueObject>> GetRouteForAddress(AddressValueObject sourceAddress)
        {
            throw new System.NotImplementedException();
        }
    }
}
