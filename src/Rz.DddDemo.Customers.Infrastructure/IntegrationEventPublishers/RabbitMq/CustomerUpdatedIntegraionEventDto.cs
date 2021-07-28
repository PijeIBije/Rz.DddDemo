using System;
using System.Collections.Generic;
using Rz.DddDemo.Base.Application.IntegrationEventHandling;
using Rz.DddDemo.Base.Domain.DomainEvent;
using Rz.DddDemo.Customers.Domain;

namespace Rz.DddDemo.Customers.Infrastructure.IntegrationEventPublishers.RabbitMq
{
    public class CustomerUpdatedIntegraionEventDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public List<AddressDto> Addresses { get; set; } = new List<AddressDto>();
    }
}
