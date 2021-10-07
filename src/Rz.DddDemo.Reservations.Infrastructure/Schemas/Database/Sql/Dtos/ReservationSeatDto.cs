using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rz.DddDemo.Reservations.Infrastructure.Schemas.Database.Sql.Dtos
{
    public class ReservationSeatDto
    {
        public ReservationDto Reservation { get; set; }

        public Guid ReservationId { get; set; }

        public SeatDto Seat { get; set; }

        public int RowNumber { get; set; }

        public int SeatNumber { get; set; }
    }
}
