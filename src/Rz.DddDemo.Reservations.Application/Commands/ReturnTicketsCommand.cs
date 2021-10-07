using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rz.DddDemo.Base.Application;
using Rz.DddDemo.Base.Application.CommandHandling.Interfaces;
using Rz.DddDemo.Reservations.Domain.Ticket;

namespace Rz.DddDemo.Reservations.Application.Commands
{
    public class ReturnTicketsCommand:ICommand<NoResult>
    {
        public IEnumerable<TicketId> TicketIds { get; set; }
    }
}
