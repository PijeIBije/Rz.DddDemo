using System;
using System.Collections.Generic;
using System.Text;
using Rz.DddDemo.Base.Domain.DomainEvent;
using Rz.DddDemo.Shipping.Domain.Shipment.ValueObjects;

namespace Rz.DddDemo.Shipping.Domain.Shipment
{
    public class ShipmentAggregate:DomainEventBase<ShipmentId>
    {
        public ShipmentAggregate(ShipmentId source) : base(source)
        {
        }
    }
}
