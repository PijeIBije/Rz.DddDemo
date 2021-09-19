using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rz.DddDemo.Base.Domain;
using Rz.DddDemo.Base.Domain.DomainEvent;
using Rz.DddDemo.Shipping.Domain.Order;
using Rz.DddDemo.Shipping.Domain.Order.Address;

namespace Rz.DddDemo.Shipping.Domain.Shipment
{
    public class ShipmentAggregate:DomainEventBase<ShipmentId>
    {
        private IReadOnlyList<OrderId> OrderIds => orderIds;

        private IReadOnlyList<AddressValueObject> Route => route;

        private List<AddressValueObject> route;

        private readonly List<OrderId> orderIds;

        public bool IsShipped { get; private set; }

        public ShipmentAggregate(ShipmentId id, bool isShipped, List<OrderId> orderIds, List<AddressValueObject> route, AddressValueObject destinationAddress) : base(id)
        {
            Guard.AgainstNullValue(destinationAddress, nameof(destinationAddress));
            Guard.AgaintsNullOrEmptyValue(orderIds,nameof(orderIds));
            if(route != null) SetRoute(route);
            if(isShipped) SetShipped();
            this.orderIds = orderIds;
        }

        public ShipmentAggregate(List<OrderId> orderIds, AddressValueObject destinationAddress):this(new ShipmentId(),false,orderIds,null, destinationAddress)
        {
            
        }


        public void SetRoute(List<AddressValueObject> routeToSet)
        {
            Guard.AgaintsNullOrEmptyValue(routeToSet, nameof(routeToSet));
            if (IsShipped) throw new InvalidOperationException("Cannot set route for shipped Shipment.");
            route = routeToSet;
        }

        public void SetShipped()
        {
            if(route == null) throw new InvalidOperationException("Cannot set Shipment to shipped if not route is set.");
            IsShipped = true;
        }
    }
}
