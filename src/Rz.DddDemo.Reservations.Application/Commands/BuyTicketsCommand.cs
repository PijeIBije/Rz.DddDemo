using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Rz.DddDemo.Base.Application.CommandHandling.Interfaces;
using Rz.DddDemo.Reservations.Domain.Performance;
using Rz.DddDemo.Reservations.Domain.Reservation;
using Rz.DddDemo.Reservations.Domain.Ticket;

namespace Rz.DddDemo.Reservations.Application.Commands
{
    public class BuyTicketsCommand:ICommand<IEnumerable<TicketId>>
    {
        public ReservationId ReservationId { get; set; }

        public List<SelectedPrice> SelectedPrices { get; set; }

        public class SelectedPrice
        {
            public SeatId SeatId { get; set; }

            public PriceName Name { get; set; }
        }
    }
}
