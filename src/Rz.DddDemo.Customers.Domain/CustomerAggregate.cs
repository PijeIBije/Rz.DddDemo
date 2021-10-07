using System;
using System.Collections.Generic;
using System.Linq;
using Rz.DddDemo.Base.Domain;
using Rz.DddDemo.Base.Domain.DomainEntity;
using Rz.DddDemo.Customers.Domain.Purchase;

namespace Rz.DddDemo.Customers.Domain
{
    public class CustomerAggregate:DomainEntityBase<CustomerId>
    {
        public Name Name { get; private set; }

        public EmailAddress EmailAddress { get; private set; }

        public LegacyCustomerId LegacyCustomerId { get; private set; }

        public PhoneNumber PhoneNumber { get; private set; }

        public event DomainEventHanlder<CustomerChangedDomainEvent> CustomerChanged; 

        public CustomerAggregate(
            CustomerId id,
            Name name,
            EmailAddress emailAddress,
            PhoneNumber phoneNumber,
            LegacyCustomerId legacyCustomerId):base(id)
        {
            Guard.AgainstNullValues(new (object,string)[]
            {
                (name,nameof(name)),
                (emailAddress,nameof(emailAddress)),
                (phoneNumber,nameof(phoneNumber)),
            });

            Name = name;
            EmailAddress = emailAddress;
            PhoneNumber = phoneNumber;
            LegacyCustomerId = legacyCustomerId;
        }

        public CustomerAggregate(
            Name name,
            EmailAddress emailAddress,
            PhoneNumber phoneNumber,
            LegacyCustomerId legacyCustomerId) : this(new CustomerId(), name, emailAddress, phoneNumber,legacyCustomerId)
        {

        }

        public void Update(
            Name name,
            EmailAddress emailAddress,
            PhoneNumber phoneNumber
        )
        {
            var changed = false;

            if (name != null)
            {
                changed = true;
                Name = name;
            }

            if (emailAddress != null)
            {
                changed = true;
                EmailAddress = emailAddress;
            }

            if (phoneNumber != null)
            {
                changed = true;
                PhoneNumber = phoneNumber;
            }

            if (changed) CustomerChanged?.Invoke(new CustomerChangedDomainEvent(this));
        }
    }
}
