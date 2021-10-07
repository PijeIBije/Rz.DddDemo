using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rz.DddDemo.Base.Domain.DomainEntity;
using Rz.DddDemo.Repertory.Domain.Auditorium;
using Rz.DddDemo.Repertory.Domain.Play;

namespace Rz.DddDemo.Repertory.Domain.Performance
{
    public class PerformanceAggregate : DomainEntityBase<PerformanceId>

    {
        public PerformanceAggregate(
            PerformanceId performanceId, 
            AuditioriumId auditioriumId,
            PlayId playId, 
            DateTime performanceDate) : base(performanceId)
        {

        }

        public PerformanceAggregate(
            AuditioriumId auditioriumId,
            PlayId playId,
            DateTime performanceDate) : this(new PerformanceId(), auditioriumId, playId, performanceDate)
        {

        }

        public IReadOnlyList<SeatsPricingEntity> SeatPricings => seatPricings;

        private List<SeatsPricingEntity> seatPricings = new List<SeatsPricingEntity>();

        public void SetPricing(
            IEnumerable<Row> rows,
            PricingName pricingName, Price price)
        {

        }

        public void DisableSeats(RowNumber rowStart, RowNumber rowEnd, SeatNumber seatStart, SeatNumber seatEnd)
        {

        }
    }
}
