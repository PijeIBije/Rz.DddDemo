using System.Collections.Generic;
using Rz.DddDemo.Base.Application.CommandHandling.Interfaces;
using Rz.DddDemo.Orders.Domain.Customer.Address.ValueObjects;
using Rz.DddDemo.Orders.Domain.Customer.ValueObjects;

namespace Rz.DddDemo.Orders.Application.Commands.Order
{
    public class CreateOrderCommand:ICommand
    {
        public CustomerId CustomerId { get; set; }
        
        public AddressName AddressName { get; set; }

        public List<OrderLineData> OrderLines { get; set; }
    }
}
