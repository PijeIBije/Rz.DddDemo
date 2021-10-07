using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rz.DddDemo.Reservations.Domain.Ticket;

namespace Rz.DddDemo.Reservations.Application.Interfaces
{
    public interface ITicketRepository
    {
        Task Save(IEnumerable<TicketAggregate> tickets);
        Task<IEnumerable<TicketAggregate>> GetByIds(IEnumerable<TicketId> ticketIds);

    }
}
