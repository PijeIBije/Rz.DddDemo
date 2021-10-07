using System;
using System.Collections.Generic;
using System.Text;
using Rz.DddDemo.Base.Domain.DomainEntity;
using Rz.DddDemo.Reservations.Domain.Customer;
using Rz.DddDemo.Reservations.Domain.Performance;

namespace Rz.DddDemo.Reservations.Domain.Ticket
{
    public class TicketAggregate:DomainEntityBase<TicketId>
    {
        public CustomerId CustomerId { get; }
        public PerformanceId PerformanceId { get; }
        public SeatId SeatId { get; }
        public PriceName PriceName { get; }
        public Price Price { get; }
        public bool Returned { get; private set; }

        public TicketAggregate(
            TicketId id, 
            CustomerId customerId, 
            PerformanceId performanceId, 
            SeatId seatId, 
            PriceName priceName, 
            Price price, 
            bool returned) : base(id)
        {
            CustomerId = customerId;
            PerformanceId = performanceId;
            SeatId = seatId;
            PriceName = priceName;
            Price = price;
            Returned = returned;
        }

        public TicketAggregate(
            CustomerId customerId,
            PerformanceId performanceId,
            SeatId seatId,
            PriceName priceName,
            Price price):this(new TicketId(), customerId,performanceId,seatId,priceName,price,false)
        {
            
        }

        public void Return()
        {
            Returned = true;
        }
    }
}
