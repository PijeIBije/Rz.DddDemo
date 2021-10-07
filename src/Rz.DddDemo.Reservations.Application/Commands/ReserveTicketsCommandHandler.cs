using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rz.DddDemo.Base.Application;
using Rz.DddDemo.Base.Application.CommandHandling;
using Rz.DddDemo.Base.Application.DomainEventHandling;
using Rz.DddDemo.Base.Application.IntegrationEventHandling;
using Rz.DddDemo.Base.Application.TransactionHandling;
using Rz.DddDemo.Reservations.Application.Interfaces;
using Rz.DddDemo.Reservations.Domain.Reservation;

namespace Rz.DddDemo.Reservations.Application.Commands
{
    public class ReserveSeatsCommandHandler:CommandHandlerBase<ReserveSeatsCommand,ReservationId>
    {
        private readonly IReservationRepository reservationRepository;
        private readonly IPerformanceRepository performanceRepository;

        public ReserveSeatsCommandHandler(
            IReservationRepository reservationRepository,
            IPerformanceRepository performanceRepository,
            DomainEventsHandler domainEventsHandler, 
            IntegrationEventsPublisher integrationEventsPublisher,
            Transaction transaction) : base(domainEventsHandler, integrationEventsPublisher, transaction)
        {
            this.reservationRepository = reservationRepository;
            this.performanceRepository = performanceRepository;
        }

        protected override async Task<ReservationId> HandleBody(ReserveSeatsCommand command)
        {
            var seatsExist = await performanceRepository.SeatsFree(command.PerformanceId, command.SeatIds);

            if(!seatsExist) throw new Exception();

            var reservation = new ReservationAggregate(command.PerformanceId,command.CustomerId,command.SeatIds);

            await reservationRepository.Save(reservation);

            return reservation.Id;
        }
    }
}
