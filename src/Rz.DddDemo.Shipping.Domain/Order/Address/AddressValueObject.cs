using System;
using System.Collections.Generic;
using System.Text;
using Rz.DddDemo.Shipping.Domain.Order.Address.ValueObjects;

namespace Rz.DddDemo.Shipping.Domain.Order.Address
{
    public class AddressValueObject
    {
        public AddressLine AddressLine1 { get; }
        public AddressLine AddressLine2 { get; }
        public City City { get; }
        public PhoneNumber PhoneNumber { get; }
        public EmailAddress EmailAddress { get; }
        public Country Country { get; }

        public FirstName FirstName { get; }

        public LastName LastName { get; }

        public AddressValueObject(
            FirstName firstName, 
            LastName lastName,
            AddressLine addressLine1,
         AddressLine addressLine2,
         City city,
         PhoneNumber phoneNumber,
         EmailAddress emailAddress,
         Country country)
        {
            FirstName = firstName;
            LastName = lastName;
            AddressLine1 = addressLine1;
            AddressLine2 = addressLine2;
            City = city;
            PhoneNumber = phoneNumber;
            Country = country;
            EmailAddress = emailAddress;
        }
    }
}
