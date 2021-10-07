using System;
using System.Collections.Generic;
using System.Text;

namespace Rz.DddDemo.Reservations.Infrastructure.Schemas.Database.Sql.Dtos
{
    public class PerformanceDto
    {
        public Guid Id { get; set; }

        public List<SeatDto> Seats { get; set; }

        public List<TicketDto> Tickets { get; set; }

        public List<ReservationDto> Reservations { get; set; }
    }
}
