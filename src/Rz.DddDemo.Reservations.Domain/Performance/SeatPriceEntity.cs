using System;
using System.Collections.Generic;
using System.Text;
using Rz.DddDemo.Base.Domain.DomainEntity;

namespace Rz.DddDemo.Reservations.Domain.Performance
{
    public class SeatPriceEntity:DomainEntityBase<PriceName>
    {
        public Price Price { get; }

        public SeatPriceEntity(PriceName name, Price price) : base(name)
        {
            Price = price;
        }
    }
}
