using System;
using System.Collections.Generic;
using System.Text;

namespace Rz.DddDemo.Reservations.Infrastructure.Schemas.Database.Sql.Dtos
{
    public class SeatDto
    {
        public int SeatNumber { get; set; }

        public int RowNumber { get; set; }

        public Guid PerformanceId { get; set; }

        public List<SeatPriceDto> Prices { get; set; }

        public List<TicketDto> Tickets { get; set; }

        public List<ReservationDto> Reservations { get; set; }
    }
}
