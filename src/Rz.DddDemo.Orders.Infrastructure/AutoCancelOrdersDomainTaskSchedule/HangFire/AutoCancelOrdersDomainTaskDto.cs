using System;
using System.Collections.Generic;
using System.Text;

namespace Rz.DddDemo.Orders.Infrastructure.AutoCancelOrdersDomainTaskSchedule.HangFire
{
    public class AutoCancelOrdersDomainTaskDto
    {
        public int AutoCancellationHour  { get; set; }
    }
}
