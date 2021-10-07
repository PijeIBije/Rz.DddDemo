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
    public class CancelReservationCommandHandler : CommandHandlerBase<CancelReservationCommand>
    {
        private readonly IReservationRepository reservationRepository;

        public CancelReservationCommandHandler(
            IReservationRepository reservationRepository,
            DomainEventsHandler domainEventsHandler,
            IntegrationEventsPublisher integrationEventsPublisher,
            Transaction transaction) : base(domainEventsHandler, integrationEventsPublisher, transaction)
        {
            this.reservationRepository = reservationRepository;
        }

        protected override async Task<NoResult> HandleBody(CancelReservationCommand command)
        {
            var reservation = await reservationRepository.GetById(command.ReservationId);

            reservation.Cancel();

            await reservationRepository.Save(reservation);

            return NoResult;
        }
    }
}
