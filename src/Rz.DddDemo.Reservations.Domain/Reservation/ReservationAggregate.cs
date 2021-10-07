using System;
using System.Collections.Generic;
using System.Text;
using Rz.DddDemo.Base.Domain.DomainEntity;
using Rz.DddDemo.Reservations.Domain.Customer;
using Rz.DddDemo.Reservations.Domain.Performance;

namespace Rz.DddDemo.Reservations.Domain.Reservation
{
    public class ReservationAggregate:DomainEntityBase<ReservationId>
    {
        public PerformanceId PerformanceId { get; }
        public CustomerId CustomerId { get; }
        public IEnumerable<SeatId> SeatIds { get; }
        public ReservationStatus Status { get; }

        public ReservationAggregate(
            ReservationId id,
            PerformanceId performanceId,
            CustomerId customerId,
            IEnumerable<SeatId> seatIds,
            ReservationStatus status) : base(id)
        {
            PerformanceId = performanceId;
            CustomerId = customerId;
            SeatIds = seatIds;
            Status = status;
        }

        public ReservationAggregate(
            PerformanceId performanceId,
            CustomerId customerId,
            IEnumerable<SeatId> seatIds) : this(new ReservationId(), performanceId, customerId, seatIds,
            ReservationStatus.Values.Created)
        {

        }

        public void Cancel()
        {

        }
    }
}
