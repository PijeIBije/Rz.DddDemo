using System;
using System.Collections.Generic;
using System.Linq;
using Rz.DddDemo.Base.Domain.DomainEntity;
using Rz.DddDemo.Customers.Domain.Address;
using Rz.DddDemo.Customers.Domain.Address.ValueObjects;
using Rz.DddDemo.Customers.Domain.DomainEvents;
using Rz.DddDemo.Customers.Domain.ValueObjects;

namespace Rz.DddDemo.Customers.Domain
{
    public class CustomerAggregate:DomainEntityBase<CustomerId>
    {
        public FirstName FirstName { get; private set; }
        public LastName LastName { get; private set; }
        public DateOfBirth DateOfBirth { get; private set; }
        private readonly List<AddressEntity> addresses;

        public event DomainEventHanlder<CustomerChangedDomainEvent> CustomerChanged; 

        public IReadOnlyList<AddressEntity> Addresses => addresses;

        public CustomerAggregate(
            CustomerId id,
            FirstName firstName,
            LastName lastName,
            DateOfBirth dateOfBirth,
            IReadOnlyList<AddressEntity> addresses):base(id)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            this.addresses = addresses.ToList();
        }

        public CustomerAggregate(
            FirstName firstName,
            LastName lastName,
            DateOfBirth dateOfBirth,
            IReadOnlyList<AddressEntity> addresses) : this(new CustomerId(), firstName, lastName, dateOfBirth,
            addresses)
        {

        }

        public void Update(
            FirstName firstName,
            LastName lastName,
            DateOfBirth dateOfBirth,
            IEnumerable<AddressUpdate> addressUpdates,
            IEnumerable<AddressName> addressesToRemoveNames
        )
        {
            var changed = false;

            if (firstName != null)
            {
                changed = true;
                FirstName = firstName;
            }

            if (lastName != null)
            {
                changed = true;
                LastName = lastName;
            }

            if (dateOfBirth != null)
            {
                changed = true;
                DateOfBirth = dateOfBirth;
            }

            foreach (var addressUpdate in addressUpdates)
            {
                var addressChanged = AddOrUpdateAddress(
                    addressUpdate.Name,
                    addressUpdate.AddressLine1,
                    addressUpdate.AddressLine2,
                    addressUpdate.City,
                    addressUpdate.PhoneNumber,
                    addressUpdate.EmailAddress,
                    addressUpdate.Country);

                if (addressChanged) changed = true;
            }

            foreach (var addressToRemoveName in addressesToRemoveNames)
            {
                RemoveAddress(addressToRemoveName);
                changed = true;
            }

            if (changed) CustomerChanged?.Invoke(new CustomerChangedDomainEvent(this));
        }

        private bool AddOrUpdateAddress(AddressName addressName,
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
                return currentAddress.Update(
                    addressName,
                    addressLine1,
                    addressLine2,
                    city,
                    phoneNumber,
                    emailAddress,
                    country);
            }

            var newAddress = new AddressEntity(
                addressName,
                addressLine1,
                addressLine2,
                city,
                phoneNumber,
                emailAddress,
                country);

            addresses.Add(newAddress);

            return true;
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
