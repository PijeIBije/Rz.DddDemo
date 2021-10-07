using System;
using System.Collections.Generic;
using System.Text;

namespace Rz.DddDemo.Reservations.Infrastructure.Schemas.Database.Sql.Dtos
{
    public class TicketDto
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public Guid PerformanceId { get; set; }
        public string PriceName { get; set; }
        public decimal Price { get; set; }
        public bool Returned { get;  set; }
        public int SeatNumber { get; set; }
        public int RowNumber { get; set; }
        public Guid ReservationId { get; set; }
        public SeatDto Seat { get; set; }
        public ReservationDto Reservation { get; set; }
    }
}
