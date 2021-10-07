using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rz.DddDemo.Reservations.Domain.Reservation;

namespace Rz.DddDemo.Reservations.Application.Interfaces
{
    public interface IReservationRepository
    {
        Task Save(ReservationAggregate reservation);

        Task<ReservationAggregate> GetById(ReservationId reservationId);
    }
}
