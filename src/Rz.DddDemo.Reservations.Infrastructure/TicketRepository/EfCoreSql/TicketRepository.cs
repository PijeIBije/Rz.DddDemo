using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Rz.DddDemo.Base.Application.TransactionHandling.Interfaces;
using Rz.DddDemo.Base.Infrastructure.EntityFramework;
using Rz.DddDemo.Base.Mapping.Interface;
using Rz.DddDemo.Reservations.Application.Interfaces;
using Rz.DddDemo.Reservations.Domain.Ticket;
using Rz.DddDemo.Reservations.Infrastructure.Schemas.Database.Sql;
using Rz.DddDemo.Reservations.Infrastructure.Schemas.Database.Sql.Dtos;

namespace Rz.DddDemo.Reservations.Infrastructure.TicketRepository.EfCoreSql
{
    public class TicketRepository:EfRepositoryBase<ReservationsDbContext>, ITicketRepository
    {
        private readonly IMapper mapper;

        public TicketRepository(
            IMapper mapper,
            IDbContextFactory<ReservationsDbContext> dbContextFactory,
            ITransactionEvents transactionEvents) : base(dbContextFactory, transactionEvents)
        {
            this.mapper = mapper;
        }

        public Task Save(IEnumerable<TicketAggregate> tickets)
        {
            var ticketDtos = tickets.Select(ticket => mapper.Map<TicketAggregate, TicketDto>(ticket));

            DbContext.Tickets.UpdateRange(ticketDtos);

            return Task.CompletedTask;
        }

        public async Task<IEnumerable<TicketAggregate>> GetByIds(IEnumerable<TicketId> ticketIds)
        {
            var ticketDtos = await DbContext.Tickets.Where(x => ticketIds.Any(y=>y.Value == x.Id)).ToListAsync();

            var tickets = ticketDtos.Select(x => mapper.Map<TicketDto, TicketAggregate>(x));

            return tickets;
        }
    }
}
