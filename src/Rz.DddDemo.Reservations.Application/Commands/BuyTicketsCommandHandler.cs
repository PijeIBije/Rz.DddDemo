using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rz.DddDemo.Base.Application.CommandHandling;
using Rz.DddDemo.Base.Application.DomainEventHandling;
using Rz.DddDemo.Base.Application.IntegrationEventHandling;
using Rz.DddDemo.Base.Application.TransactionHandling;
using Rz.DddDemo.Reservations.Application.Interfaces;
using Rz.DddDemo.Reservations.Domain.Ticket;

namespace Rz.DddDemo.Reservations.Application.Commands
{
    public class BuyTicketsCommandHandler:CommandHandlerBase<BuyTicketsCommand,IEnumerable<TicketId>>
    {
        private readonly ITicketRepository ticketRepository;
        private readonly IReservationRepository reservationRepository;
        private readonly IPerformanceRepository performanceRepository;
        private readonly ICustomerRepository customerRepository;

        public BuyTicketsCommandHandler(
            ITicketRepository ticketRepository,
            IReservationRepository reservationRepository,
            IPerformanceRepository performanceRepository,
            ICustomerRepository customerRepository,
            DomainEventsHandler domainEventsHandler,
            IntegrationEventsPublisher integrationEventsPublisher, Transaction transaction) : base(domainEventsHandler,
            integrationEventsPublisher, transaction)
        {
            this.ticketRepository = ticketRepository;
            this.reservationRepository = reservationRepository;
            this.performanceRepository = performanceRepository;
            this.customerRepository = customerRepository;
        }

        protected override async Task<IEnumerable<TicketId>> HandleBody(BuyTicketsCommand command)
        {
            var reservation = await reservationRepository.GetById(command.ReservationId);

            var performance = await performanceRepository.GetById(reservation.PerformanceId);

            var customer = await customerRepository.GetById(reservation.CustomerId);

            var tickets = new List<TicketAggregate>();

            foreach (var selectedPrice in command.SelectedPrices)
            {
                var seat = performance.Seats.Single(x => x.Id == selectedPrice.SeatId);

                var price = seat.Prices.Single(x => x.Id == selectedPrice.Name).Price;

                var finalPrice = price.ApplyDiscount(customer.CurrentDiscount);

                var ticket = new TicketAggregate(customer.Id,performance.Id,seat.Id,selectedPrice.Name,finalPrice);

                tickets.Add(ticket);
            }

            await ticketRepository.Save(tickets);

            return tickets.Select(x => x.Id);
        }
    }
}
