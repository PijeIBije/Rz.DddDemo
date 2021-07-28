using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Rz.DddDemo.Shipping.Application.Interfaces;
using Rz.DddDemo.Shipping.Domain.Order.Address;

namespace Rz.DddDemo.Shipping.Infrastructure.GetRoutesForAddress.AllRouteProviders
{
    public class GetRouteForAddressOperation:IGetRouteForAddressOperation
    {
        private readonly RouteProviderA.HttpClient.GetRouteForAddressOperation getRouteForAddressOperationFromProviderA;
        private readonly RouteProviderB.Mock.GetRouteForAddressOperation getRouteForAddressOperationFromProviderB;
        private readonly RouteProviderC.WcfClient.GetRouteForAddressOperation getRouteForAddressOperationFromProviderC;

        public GetRouteForAddressOperation(
            RouteProviderA.HttpClient.GetRouteForAddressOperation getRouteForAddressOperationFromProviderA,
            RouteProviderB.Mock.GetRouteForAddressOperation getRouteForAddressOperationFromProviderB,
            RouteProviderC.WcfClient.GetRouteForAddressOperation getRouteForAddressOperationFromProviderC)
        {
            this.getRouteForAddressOperationFromProviderA = getRouteForAddressOperationFromProviderA;
            this.getRouteForAddressOperationFromProviderB = getRouteForAddressOperationFromProviderB;
            this.getRouteForAddressOperationFromProviderC = getRouteForAddressOperationFromProviderC;
        }


        public async Task<List<AddressValueObject>> GetRouteForAddress(AddressValueObject sourceAddress)
        {
            var cancellationTokenSource = new CancellationTokenSource();

            var providerATask = getRouteForAddressOperationFromProviderA.GetRouteForAddress(sourceAddress,cancellationTokenSource.Token);
            var providerBTask = getRouteForAddressOperationFromProviderB.GetRouteForAddress(sourceAddress,cancellationTokenSource.Token);

            var providerParalellTasks = new[] {providerATask, providerBTask};
            var completedTasks = new List<Task<List<AddressValueObject>>>();
            while (completedTasks.Count != providerParalellTasks.Length)
            {
                var completedTask = await Task.WhenAny(providerParalellTasks);

                if (!completedTask.IsFaulted)
                {
                    var result = completedTask.Result;

                    if (result.Any())
                    {
                        cancellationTokenSource.Cancel();
                        return result;
                    }
                }

                completedTasks.Add(completedTask);
            }

            var routeProviderCResult = await getRouteForAddressOperationFromProviderC.GetRouteForAddress(sourceAddress);

            if (!routeProviderCResult.Any())
            {
                throw new NoAvailableRouteException(sourceAddress);
            }

            return routeProviderCResult;
        }
    }

    public class NoAvailableRouteException : Exception
    {
        public AddressValueObject SourceAddress { get; }

        public NoAvailableRouteException(AddressValueObject sourceAddress):base($"No available route for address {sourceAddress.ToString()}")
        {
            SourceAddress = sourceAddress;
        }
    }
}
