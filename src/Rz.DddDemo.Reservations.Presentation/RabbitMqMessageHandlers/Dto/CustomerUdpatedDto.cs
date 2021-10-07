using System;
using System.Collections.Generic;

namespace Rz.DddDemo.Reservations.Presentation.RabbitMqMessageHandlers.Dto
{
    public class CustomerUdpatedDto
    {
        public Guid CustomerId { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public List<AddressDto> AddressDtos { get; set; }

        public List<string> AddressNamesToRemove { get; set; }
    }
}
