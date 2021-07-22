namespace Rz.DddDemo.Customers.Infrastructure.IntegrationEventsPublishers.RabbitMq
{
    public class AddressDto
    {
        public string Name { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string Country { get; set; }
    }
}
