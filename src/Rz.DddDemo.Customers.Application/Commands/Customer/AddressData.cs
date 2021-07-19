using System;
using System.Collections.Generic;
using System.Text;
using Rz.DddDemo.Customers.Domain.CustomerAggregate.AddressAggregate.ValueObjects;

namespace Rz.DddDemo.Customers.Application.Commands.Customer
{
    public class AddressData
    {
        public AddressName Name { get; set; }
        public AddressLine AddressLine1 { get; set; }
        public AddressLine AddressLine2 { get; set; }
        public City City { get; set; }
        public PhoneNumber PhoneNumber { get; set; }
        public EmailAddress EmailAddress { get; set; }
        public Country Country { get; set; }
    }
}
