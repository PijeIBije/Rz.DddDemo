using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rz.DddDemo.Orders.Domain.Customer.Address.ValueObjects;

namespace Rz.DddDemo.Orders.Presentation.WebApi.Controllers.Order
{
    public class ShippingAddressResource
    {
        public AddressName Name { get; }
        public AddressLine AddressLine1 { get; }
        public AddressLine AddressLine2 { get; }
        public City City { get; }
        public PhoneNumber PhoneNumber { get; }
        public EmailAddress EmailAddress { get; }
        public Country Country { get; }
    }
}
