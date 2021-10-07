using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rz.DddDemo.Base.Application.CommandHandling.Interfaces;
using Rz.DddDemo.Repertory.Domain.Auditorium;
using Rz.DddDemo.Repertory.Domain.Performance;
using Rz.DddDemo.Repertory.Domain.Play;

namespace Rz.DddDemo.Repertory.Application.Commands
{
    public class CreatePerformanceCommand:ICommand<PerformanceId>
    {
        public PlayId PlayId { get; set; }

        public AuditioriumId AuditioriumId { get; set; }

        public DateTime PerformanceDate { get; set; }

        public IEnumerable<SeatPricingCreationData> SeatPricings { get; set; }

        public class SeatPricingCreationData
        {
            public PricingName PricingName { get; set; }

            public IEnumerable<Row> Rows { get; set; }

            public Price Price { get; set; }
        }
    }
}
