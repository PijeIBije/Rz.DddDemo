using System;
using System.Collections.Generic;
using System.Linq;
using Rz.DddDemo.Base.Domain.DomainEntity;
using Rz.DddDemo.Orders.Domain.Customer.Address;
using Rz.DddDemo.Orders.Domain.Customer.Address.ValueObjects;
using Rz.DddDemo.Orders.Domain.Customer.DomainEvents;
using Rz.DddDemo.Orders.Domain.Customer.ValueObjects;

namespace Rz.DddDemo.Orders.Domain.Customer
{
    public class CustomerAggregate:DomainEntityBase<CustomerId>
    {
        public event DomainEventHanlder<CustomerUpdatedDomainEvent> CustomerUpdated;

        public FirstName FirstName { get; private set; }
        public LastName LastName { get; private set; }

        private readonly List<Address.AddressValueObject> addresses;

        public IReadOnlyList<Address.AddressValueObject> Addresses => addresses;

        public CustomerAggregate(
            CustomerId id,
            FirstName firstName,
            LastName lastName,
            IReadOnlyList<Address.AddressValueObject> addresses):base(id)
        {
            FirstName = firstName;
            LastName = lastName;
            this.addresses = addresses.ToList();
        }

        public CustomerAggregate(
            FirstName firstName,
            LastName lastName,
            IReadOnlyList<Address.AddressValueObject> addresses) : this(new CustomerId(), firstName, lastName,
            addresses)
        {

        }

        public void Update(
            FirstName firstName,
            LastName lastName,
            IList<AddressValueObject> newAddresses)
        {
            var customerUpdated = false;

            if (firstName != null && FirstName != firstName)
            {
                FirstName = firstName;
                customerUpdated = true;
            }

            if (lastName != null && LastName != lastName)
            {
                LastName = lastName;
                customerUpdated = true;
            }

            var updatedAddresNames = new List<AddressName>();

            foreach (var newAddress in newAddresses)
            {
                var existingAddress = Addresses.SingleOrDefault(x => x.Name == newAddress.Name);

                if (existingAddress == null)
                {
                    this.addresses.Add(newAddress);
                    customerUpdated = true;
                }
                else
                {
                    if (newAddress != existingAddress)
                    {
                        addresses.Remove(existingAddress);
                        addresses.Add(newAddress);
                        updatedAddresNames.Add(newAddress.Name);
                        customerUpdated = true;
                    }
                }

                var countRemoved = addresses.RemoveAll(x => newAddresses.All(y => y.Name != x.Name));

                if (countRemoved > 0) customerUpdated = true;
            }

            if(customerUpdated) CustomerUpdated?.Invoke(new CustomerUpdatedDomainEvent(this,updatedAddresNames));
        }

        public void AddOrUpdateAddress(Address.AddressValueObject newAddress)
        {
            var currentAddress = addresses.SingleOrDefault(x => x.Name == newAddress.Name);

            if (currentAddress != null)
            {
                addresses.Remove(currentAddress);
            }

            addresses.Add(newAddress);



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
