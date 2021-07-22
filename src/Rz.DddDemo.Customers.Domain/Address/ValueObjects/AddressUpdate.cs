namespace Rz.DddDemo.Customers.Domain.Address.ValueObjects
{
    public class AddressUpdate
    {
        public AddressName Name { get; set; }
        public AddressLine AddressLine1 { get; set; }
        public AddressLine AddressLine2 { get; set; }
        public City City { get; set; }
        public PhoneNumber PhoneNumber { get; set; }
        public EmailAddress EmailAddress { get; set; }
        public Country Country { get; set; }
    }
}
