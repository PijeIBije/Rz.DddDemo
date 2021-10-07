using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rz.DddDemo.Base.Domain.DomainEntity;

namespace Rz.DddDemo.Reservations.Domain.Performance
{
    public class PerformanceAggregate:DomainEntityBase<PerformanceId>
    {
        public IReadOnlyList<SeatEntity> Seats => seats;

        private readonly List<SeatEntity> seats;

        protected PerformanceAggregate(PerformanceId id, IEnumerable<SeatEntity> seats) : base(id)
        {
            this.seats = this.seats.ToList();
        }
    }
}
