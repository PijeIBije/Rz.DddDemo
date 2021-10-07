using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rz.DddDemo.Base.Application;
using Rz.DddDemo.Base.Application.CommandHandling.Interfaces;
using Rz.DddDemo.Reservations.Domain.Reservation;

namespace Rz.DddDemo.Reservations.Application.Commands
{
    public class CancelReservationCommand:ICommand<NoResult>
    {
        public ReservationId ReservationId { get; set; }
    }
}
