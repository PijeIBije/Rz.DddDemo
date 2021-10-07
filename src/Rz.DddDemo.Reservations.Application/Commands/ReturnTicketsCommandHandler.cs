using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Rz.DddDemo.Base.Application;
using Rz.DddDemo.Base.Application.CommandHandling;
using Rz.DddDemo.Base.Application.CommandHandling.Interfaces;
using Rz.DddDemo.Base.Application.DomainEventHandling;
using Rz.DddDemo.Base.Application.IntegrationEventHandling;
using Rz.DddDemo.Base.Application.TransactionHandling;
using Rz.DddDemo.Reservations.Application.Interfaces;

namespace Rz.DddDemo.Reservations.Application.Commands
{
    public class ReturnTicketsCommandHandler:CommandHandlerBase<ReturnTicketsCommand>
    {
        private readonly ITicketRepository ticketRepository;

        public ReturnTicketsCommandHandler(
            ITicketRepository ticketRepository,
            DomainEventsHandler domainEventsHandler, 
            IntegrationEventsPublisher integrationEventsPublisher, 
            Transaction transaction) : base(domainEventsHandler, integrationEventsPublisher, transaction)
        {
            this.ticketRepository = ticketRepository;
        }

        protected override async Task<NoResult> HandleBody(ReturnTicketsCommand command)
        {
            var tickets = (await ticketRepository.GetByIds(command.TicketIds)).ToList();

            foreach (var ticket in tickets)
            {
                ticket.Return();
            }

            await ticketRepository.Save(tickets);

            return NoResult;
        }
    }
}
