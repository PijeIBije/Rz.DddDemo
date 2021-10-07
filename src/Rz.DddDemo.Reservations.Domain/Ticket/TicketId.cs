using System;
using System.Collections.Generic;
using System.Text;
using Rz.DddDemo.Base.Domain.ValueObject;

namespace Rz.DddDemo.Reservations.Domain.Ticket
{
    public class TicketId : GuidValueObjectBase
    {
        public TicketId()
        {
        }

        public TicketId(Guid value) : base(value)
        {
        }

        public static implicit operator TicketId(Guid value) => new TicketId(value);
    }
}
