using System;
using System.Collections.Generic;
using System.Text;
using Rz.DddDemo.Base.Domain.ValueObject;

namespace Rz.DddDemo.Shipping.Domain.Shipment.ValueObjects
{
    public class ShipmentId:GuidValueObjectBase
    {
        public ShipmentId()
        {
            
        }

        public ShipmentId(Guid value):base(value)
        {
            
        }

        public static implicit operator ShipmentId(Guid value) => new ShipmentId(value);
    }
}
