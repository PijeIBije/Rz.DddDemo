using Rz.DddDemo.Customers.Domain.CustomerAggregate.AddressAggregate.ValueObjects;
using Rz.DddDemo.Base.Domain;
using Rz.DddDemo.Base.Domain.DomainEntity;

namespace Rz.DddDemo.Customers.Domain.CustomerAggregate.AddressAggregate
{
    public class Address:DomainEntityBase<AddressName>
    {
        public AddressName Name { get; private set; }
        public AddressLine AddressLine1 { get;private set; }
        public AddressLine AddressLine2 { get; private set; }
        public City City { get; private set; }
        public PhoneNumber PhoneNumber { get; private set; }
        public EmailAddress EmailAddress { get; private set; }
        public Country Country { get; private set; }

        public Address(
            AddressName name,
            AddressLine addressLine1,
            AddressLine addressLine2,
            City city,
            PhoneNumber phoneNumber,
            EmailAddress emailAddress,
            Country country) : base(name)
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

        public void Update(
            AddressName name,
            AddressLine addressLine1,
            AddressLine addressLine2,
            City city,
            PhoneNumber phoneNumber,
            EmailAddress emailAddress,
            Country country)
        {
            if (name != null) Name = name;
            if (addressLine1 != null) AddressLine1 = addressLine1;
            if (addressLine2 != null) AddressLine2 = addressLine2;
            if (city != null) City = city;
            if (phoneNumber != null) PhoneNumber = phoneNumber;
            if (emailAddress != null) EmailAddress = emailAddress;
            if (country != null) Country = country;
        }
    }
}
