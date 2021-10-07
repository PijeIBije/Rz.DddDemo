using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rz.DddDemo.Base.Domain.DomainEntity;
using Rz.DddDemo.Base.Domain.DomainEvent;
using Rz.DddDemo.Repertory.Domain.Auditorium;

namespace Rz.DddDemo.Repertory.Domain.Performance
{
    public class SeatsPricingEntity:DomainEntityBase<PricingName>
    {
        public PricingName Name => Id;

        public Price Price { get; }

        public IReadOnlyList<Row> Rows;

        private List<Row> rows;

        public SeatsPricingEntity(PricingName name, Price price, IEnumerable<Row> rows) : base(name)
        {
            Price = price;
            this.rows = rows.ToList();
        }
         
        public void Update(Price price, IEnumerable<Row> rows)
        {
            this.rows = rows.ToList();
        }

        public void DisableSeats(IEnumerable<Row> rows)
        {

        }
    }
}
