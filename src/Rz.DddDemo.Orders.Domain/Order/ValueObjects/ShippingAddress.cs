using Rz.DddDemo.Orders.Domain.Customer.Address;
using Rz.DddDemo.Orders.Domain.Customer.Address.ValueObjects;
using Rz.DddDemo.Orders.Domain.Customer.ValueObjects;

namespace Rz.DddDemo.Orders.Domain.Order.ValueObjects
{
    public class ShippingAddress
    {
        public AddressName Name { get; }
        public AddressLine AddressLine1 { get; }
        public AddressLine AddressLine2 { get; }
        public City City { get; }
        public PhoneNumber PhoneNumber { get; }
        public EmailAddress EmailAddress { get; }
        public Country Country { get; }

        public FirstName FirstName { get;}

        public LastName LastName { get;}

        public ShippingAddress(FirstName firstName, LastName lastName, Address address)
        {
            FirstName = firstName;
            LastName = lastName;
            Name = address.Name;
            AddressLine1 = address.AddressLine1;
            AddressLine2 = address.AddressLine2;
            City = address.City;
            PhoneNumber = address.PhoneNumber;
            Country = address.Country;
            EmailAddress = address.EmailAddress;
        }
    }
}
