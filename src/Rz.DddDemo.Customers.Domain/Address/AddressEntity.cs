using Rz.DddDemo.Base.Domain;
using Rz.DddDemo.Base.Domain.DomainEntity;
using Rz.DddDemo.Customers.Domain.Address.ValueObjects;

namespace Rz.DddDemo.Customers.Domain.Address
{
    public class AddressEntity:DomainEntityBase<AddressName>
    {
        public AddressName Name { get; private set; }
        public AddressLine AddressLine1 { get;private set; }
        public AddressLine AddressLine2 { get; private set; }
        public City City { get; private set; }
        public PhoneNumber PhoneNumber { get; private set; }
        public EmailAddress EmailAddress { get; private set; }
        public Country Country { get; private set; }

        public AddressEntity(
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

        public bool Update(
            AddressName name,
            AddressLine addressLine1,
            AddressLine addressLine2,
            City city,
            PhoneNumber phoneNumber,
            EmailAddress emailAddress,
            Country country)
        {
            var changed = false;

            if (name != null)
            {
                changed = true;
                Name = name;
            }

            if (addressLine1 != null)
            {
                changed = true;
                AddressLine1 = addressLine1;
            }

            if (addressLine2 != null)
            {
                changed = true;
                AddressLine2 = addressLine2;
            }

            if (city != null)
            {
                changed = true;
                City = city;
            }

            if (phoneNumber != null)
            {
                changed = true;
                PhoneNumber = phoneNumber;
            }

            if (emailAddress != null)
            {
                changed = true;
                EmailAddress = emailAddress;
            }

            if (country != null)
            {
                changed = true;
                Country = country;
            }

            return changed;
        }
    }
}
