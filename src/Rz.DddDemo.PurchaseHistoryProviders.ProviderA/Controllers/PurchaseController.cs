using System;
using System.Collections.Generic;
using System.Threading;
using Microsoft.AspNetCore.Mvc;

namespace Rz.DddDemo.PurchaseHistoryProviders.ProviderA.Controllers
{
    [ApiController]
    [Route("Customer/{id}/[controller]")]
    public class PurchaseController : ControllerBase
    {
        [HttpGet]
        public ActionResult<PurchaseResource> Get(string customerId)
        {
            if (customerId.EndsWith("1"))
            {
                Thread.Sleep(10000);
            }

            return Ok(MockData);
        }

        private static readonly List<PurchaseResource> MockData = new List<PurchaseResource>
        {
            new PurchaseResource
            {
                PurchaseDate = DateTime.Now.AddMonths(-1),
                Products = new List<ProductResource>
                {
                    new ProductResource
                    {
                        ProductId = "TicketPremium",
                        Description = "Tickets for Pan Tadeush Premium Seats",
                        PricePerItem = 100,
                        Quantity = 2
                    },

                    new ProductResource
                    {
                        ProductId = "TicketPlebian",
                        Description = "Tickets for Pan Tadeush Plebeyan Seats`",
                        PricePerItem = 20,
                        Quantity = 20
                    },
                }
            },
            new PurchaseResource
            {
                PurchaseDate = DateTime.Now.AddMonths(-3),
                Products = new List<ProductResource>
                {
                    new ProductResource
                    {
                        ProductId = "PencelLimited",
                        Description = "Limited theatree pencil",
                        PricePerItem = 13.55m,
                        Quantity = 1
                    }
                }
            },
            new PurchaseResource
            {
                Returned = true,
                PurchaseDate = DateTime.Now.AddMonths(-3),
                Products = new List<ProductResource>
                {
                    new ProductResource
                    {
                        ProductId = "TicketPlebian",
                        Description = "Tickets for Antygona",
                        PricePerItem = 20m,
                        Quantity = 1
                    }
                },
            }
        };
    }
}
