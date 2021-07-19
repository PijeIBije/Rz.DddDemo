using System;
using System.Collections.Generic;
using System.Linq;
using Rz.DddDemo.Base.Domain.DomainEntity;
using Rz.DddDemo.Orders.Domain.Customer.Address.ValueObjects;
using Rz.DddDemo.Orders.Domain.Customer.DomainEvents;
using Rz.DddDemo.Orders.Domain.Customer.ValueObjects;

namespace Rz.DddDemo.Orders.Domain.Customer
{
    public class Customer:DomainEntityBase<CustomerId>
    {
        public event DomainEventHanlder<CustomerUpdated> CustomerUpdated; 
        public FirstName FirstName { get; private set; }
        public LastName LastName { get; private set; }

        private readonly List<Address.Address> addresses;

        public IReadOnlyList<Address.Address> Addresses => addresses;

        public Customer(
            CustomerId id,
            FirstName firstName,
            LastName lastName,
            IReadOnlyList<Address.Address> addresses):base(id)
        {
            FirstName = firstName;
            LastName = lastName;
            this.addresses = addresses.ToList();
        }

        public Customer(
            FirstName firstName,
            LastName lastName,
            IReadOnlyList<Address.Address> addresses) : this(new CustomerId(), firstName, lastName,
            addresses)
        {

        }

        public void Update(
            FirstName firstName,
            LastName lastName)
        {
            if(firstName != null) FirstName = firstName;
            if(lastName!=null)LastName = lastName;
        }

        public void AddOrUpdateAddress(Address.Address newAddress)
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
