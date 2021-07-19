using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rz.DddDemo.Orders.Presentation.WebApi.RabbitMqMessageHandlers.Dto
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
