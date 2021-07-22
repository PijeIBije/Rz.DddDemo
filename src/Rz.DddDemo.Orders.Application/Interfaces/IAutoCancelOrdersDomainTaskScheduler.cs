using System;
using System.Collections.Generic;
using System.Text;
using Rz.DddDemo.Orders.Application.DomainTasks.Order;

namespace Rz.DddDemo.Orders.Application.Interfaces
{
    public interface IAutoCancelOrdersDomainTaskScheduler
    {
        public void Reschedule(AutoCancelOrdersDomainTask domainTask);
    }
}
