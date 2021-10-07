using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rz.DddDemo.Base.Application;
using Rz.DddDemo.Base.Application.CommandHandling.Interfaces;
using Rz.DddDemo.Reservations.Domain.Customer;
using Rz.DddDemo.Reservations.Domain.Performance;
using Rz.DddDemo.Reservations.Domain.Reservation;

namespace Rz.DddDemo.Reservations.Application.Commands
{
    public class ReserveSeatsCommand:ICommand<ReservationId>
    {
        public PerformanceId PerformanceId { get; set; }

        public CustomerId CustomerId { get; set; }

        public IEnumerable<SeatId> SeatIds { get; set; }
    }
}
