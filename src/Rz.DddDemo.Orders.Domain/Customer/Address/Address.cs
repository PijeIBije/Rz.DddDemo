using Rz.DddDemo.Base.Domain;
using Rz.DddDemo.Orders.Domain.Customer.Address.ValueObjects;

namespace Rz.DddDemo.Orders.Domain.Customer.Address
{
    public class Address
    {
        public AddressName Name { get; }
        public AddressLine AddressLine1 { get; }
        public AddressLine AddressLine2 { get; }
        public City City { get; }
        public PhoneNumber PhoneNumber { get; }
        public EmailAddress EmailAddress { get; }
        public Country Country { get; }

        public Address(
            AddressName name,
            AddressLine addressLine1,
            AddressLine addressLine2,
            City city,
            PhoneNumber phoneNumber,
            EmailAddress emailAddress,
            Country country)
        {
            Name = name;
            AddressLine1 = addressLine1;
            AddressLine2 = addressLine2;
            City = city;
            PhoneNumber = phoneNumber;
            EmailAddress = emailAddress;
            Country = country;

            Guard.AgainstNullValue(addressLine1,nameof(addressLine1));
            Guard.AgainstNullValue(city,nameof(city));
            Guard.AgainstNullValue(country, nameof(country));
            Guard.AgainstNullValue(emailAddress, nameof(emailAddress));
            Guard.AgainstNullValue(phoneNumber, nameof(phoneNumber));
        }
    }
}
