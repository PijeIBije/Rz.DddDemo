using System;
using System.Collections.Generic;
using System.Linq;
using Rz.DddDemo.Customers.Domain.CustomerAggregate.AddressAggregate;
using Rz.DddDemo.Customers.Domain.CustomerAggregate.AddressAggregate.ValueObjects;
using Rz.DddDemo.Customers.Domain.CustomerAggregate.ValueObjects;
using Rz.DddDemo.Base.Domain.DomainEntity;

namespace Rz.DddDemo.Customers.Domain.CustomerAggregate
{
    public class Customer:DomainEntityBase<CustomerId>
    {
        public FirstName FirstName { get; private set; }
        public LastName LastName { get; private set; }
        public DateOfBirth DateOfBirth { get; private set; }
        private readonly List<Address> addresses;

        public IReadOnlyList<Address> Addresses => addresses;

        public Customer(
            CustomerId id,
            FirstName firstName,
            LastName lastName,
            DateOfBirth dateOfBirth,
            IReadOnlyList<Address> addresses):base(id)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            this.addresses = addresses.ToList();
        }

        public Customer(
            FirstName firstName,
            LastName lastName,
            DateOfBirth dateOfBirth,
            IReadOnlyList<Address> addresses) : this(new CustomerId(), firstName, lastName, dateOfBirth,
            addresses)
        {

        }

        public void Update(
            FirstName firstName,
            LastName lastName,
            DateOfBirth dateOfBirth)
        {
            if (firstName != null) FirstName = firstName;
            if (lastName != null) LastName = lastName;
            if (dateOfBirth != null) DateOfBirth = dateOfBirth;
        }

        public void AddOrUpdateAddress(AddressName addressName,
            AddressLine addressLine1,
            AddressLine addressLine2,
            City city,
            PhoneNumber phoneNumber,
            EmailAddress emailAddress,
            Country country)
        {
            var currentAddress = addresses.SingleOrDefault(x => x.Name == addressName);

            if (currentAddress != null)
            {
                currentAddress.Update(
                    addressName,
                    addressLine1,
                    addressLine2,
                    city,
                    phoneNumber,
                    emailAddress,
                    country);
            }
            else
            {
                var newAddress = new Address(
                    addressName,
                    addressLine1,
                    addressLine2,
                    city,
                    phoneNumber,
                    emailAddress,
                    country);

                addresses.Add(newAddress);
            }
        }

        public void RemoveAddress(AddressName addressName)
        {
            var currentAddress = addresses.SingleOrDefault(x => x.Name == addressName);

            if (currentAddress != null)
            {
                addresses.Remove(currentAddress);
            }
            else
            {
                throw new InvalidOperationException($"Address with name {addressName} not present.");
            }
        }
    }
}
