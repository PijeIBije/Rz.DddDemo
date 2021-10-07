using System;
using System.Collections.Generic;
using System.Text;

namespace Rz.DddDemo.Reservations.Infrastructure.Schemas.Database.Sql.Dtos
{
    public class ReservationDto
    {
        public Guid Id { get; set; }

        public Guid PerformanceId { get; set; }
        public Guid CustomerId { get; set; }

        public string Status { get; set; }

        public CustomerDto Customer { get; set; }

        public List<TicketDto> Tickets { get; set; }

        public List<SeatDto> Seats { get; set; }
    }
}
