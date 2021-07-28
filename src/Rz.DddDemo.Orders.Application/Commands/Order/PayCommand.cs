using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;
using Rz.DddDemo.Base.Application.CommandHandling.Interfaces;
using Rz.DddDemo.Orders.Domain.Order.ValueObjects;

namespace Rz.DddDemo.Orders.Application.Commands.Order
{
    public class PayCommand:ICommand
    {
        public OrderId OrderId { get; set; }
    }
}
