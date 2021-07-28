﻿using Rz.DddDemo.Base.Application.DomainTaskHandling.Interfaces;
using Rz.DddDemo.Orders.Domain.AutoCancellationParameters.ValueObjects;

namespace Rz.DddDemo.Orders.Application.DomainTasks.Order
{
    public class AutoCancelOrdersDomainTask:IDomainTask
    {
        public AutoCancellationHour AutoCancellationHour { get; set; }
    }
}
