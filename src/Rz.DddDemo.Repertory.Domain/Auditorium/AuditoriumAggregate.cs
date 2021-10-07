using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rz.DddDemo.Base.Domain.DomainEntity;

namespace Rz.DddDemo.Repertory.Domain.Auditorium
{
    public class AuditoriumAggregate:DomainEntityBase<AuditioriumId>
    {
        public IReadOnlyList<Row> Seats => seats;
        public AuditoriumName AuditoriumName { get; }

        private readonly List<Row> seats;

        public AuditoriumAggregate(AuditioriumId auditioriumId, IReadOnlyList<Row> seats, AuditoriumName auditoriumName):base(auditioriumId)
        {
            this.seats = seats.ToList();
            AuditoriumName = auditoriumName;
        }

        public AuditoriumAggregate(IReadOnlyList<Row> seats, AuditoriumName auditoriumName):this(new AuditioriumId(),seats,auditoriumName) 
        {
            
        }

        public bool RowsExist(IEnumerable<Row> rows)
        {
            return true;
        }
    }
}
