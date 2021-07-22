using System;
using System.Collections.Generic;

namespace Rz.DddDemo.Orders.Presentation.WebApi.RabbitMqMessageHandlers.Dto
{
    public class CustomerCreatedDto
    {
        public Guid CustomerId { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public List<AddressDto> AddressDtos { get; set; }
    }
}
