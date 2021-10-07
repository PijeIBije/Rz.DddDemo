using System.Collections.Generic;
using System.Linq;
using Rz.DddDemo.Base.Domain.DomainEntity;

namespace Rz.DddDemo.Reservations.Domain.Performance
{
    public class SeatEntity:DomainEntityBase<SeatId>
    {
        public IReadOnlyList<SeatPriceEntity> Prices => prices;

        private readonly List<SeatPriceEntity> prices;

        public SeatEntity(SeatId id, IEnumerable<SeatPriceEntity> prices) : base(id)
        {
            this.prices = prices.ToList();
        }
    }
}
