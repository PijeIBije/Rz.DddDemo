using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Google.Protobuf.Collections;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Rz.DddDemo.PurchaseHistoryProviders.ProviderB.Protos;

namespace Rz.DddDemo.PurchaseHistoryProviders.ProviderB
{
    public class CustomerDataService:CustomerDataServiceProto.CustomerDataServiceProtoBase
    {
        public override async Task<PurchaseHisotryResponse> GetPurchaseHistory(PurchaseHistoryRequest request, ServerCallContext context)
        {
            if (request.CustomerId.EndsWith("B"))
            {
                await Task.Delay(10000);
            }

            var response = new PurchaseHisotryResponse
            {
                CustomerId = request.CustomerId,
            };

            response.Purchases.AddRange(MockData.Where(x=>request.IncludeReturned||x.PurchaseState == PurchaseState.Successful));

            return await Task.FromResult(response);
        }

        private static readonly RepeatedField<Purchase> MockData = new RepeatedField<Purchase>
        {
            new Purchase
            {
                PurchaseDate = Timestamp.FromDateTime(DateTime.Now.AddMonths(-1)),

                Items = 
                {
                    new Item
                    {
                        Name = "Tickets for Pan Tadeush Premium Seats",
                        Price = 100,
                        Quantity = 2
                    },

                    new Item
                    {
                        Name = "Tickets for Pan Tadeush Plebeyan Seats`",
                        Price = 20,
                        Quantity = 20
                    },
                }
            },
            new Purchase
            {
                PurchaseDate = Timestamp.FromDateTime(DateTime.Now.AddMonths(-3)),
                Items = 
                {
                    new Item
                    {
                        Name = "Limited theatree pencil",
                        Price = 13.55f,
                        Quantity = 1
                    }
                }
            },
            new Purchase
            {
                PurchaseDate = Timestamp.FromDateTime(DateTime.Now.AddMonths(-5)),
                Items = 
                {
                    new Item
                    {
                        Name = "Tickets for Antygona",
                        Price = 20f,
                        Quantity = 1,
                    }
                },
                PurchaseState = PurchaseState.Returned
            },
        };
    }
}
