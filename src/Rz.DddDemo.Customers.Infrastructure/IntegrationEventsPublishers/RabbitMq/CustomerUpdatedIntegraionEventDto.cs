using System;
using System.Collections.Generic;

namespace Rz.DddDemo.Customers.Infrastructure.IntegrationEventsPublishers.RabbitMq
{
    public class CustomerUpdatedIntegraionEventDto
    {
        public Guid CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public List<AddressDto> Addresses { get; set; }
    }
}
