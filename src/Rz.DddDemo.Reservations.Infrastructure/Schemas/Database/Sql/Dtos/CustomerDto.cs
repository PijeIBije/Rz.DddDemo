using System;
using System.Collections.Generic;
using System.Text;

namespace Rz.DddDemo.Reservations.Infrastructure.Schemas.Database.Sql.Dtos
{
    public class CustomerDto
    {
        public Guid Id { get; set; }

        public decimal CurrentDiscount { get; set; }

        public List<ReservationDto> Reservations { get; set; }

        public List<TicketDto> Tickets { get; set; }
    }
}
