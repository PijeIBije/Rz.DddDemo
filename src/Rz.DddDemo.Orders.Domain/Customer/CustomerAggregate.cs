using System;
using System.Collections.Generic;
using System.Linq;
using Rz.DddDemo.Base.Domain.DomainEntity;
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
            LastName lastName)
        {
            bool customerUpdated = false;

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

            if(customerUpdated) CustomerUpdated?.Invoke(new CustomerUpdatedDomainEvent(this));
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
