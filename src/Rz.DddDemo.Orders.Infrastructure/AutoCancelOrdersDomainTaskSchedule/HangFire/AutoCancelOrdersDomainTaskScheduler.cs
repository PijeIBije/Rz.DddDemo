using System;
using System.Collections.Generic;
using System.Text;
using Hangfire;
using Rz.DddDemo.Base.Mapping.Interface;
using Rz.DddDemo.Orders.Application.DomainTasks.Order;
using Rz.DddDemo.Orders.Application.Interfaces;
using Rz.DddDemo.Orders.Domain.Parameters.ValueObjects;

namespace Rz.DddDemo.Orders.Infrastructure.AutoCancelOrdersDomainTaskSchedule.HangFire
{
    public class AutoCancelOrdersDomainTaskScheduler:IAutoCancelOrdersDomainTaskScheduler
    {
        private readonly IMapper mapper;

        public AutoCancelOrdersDomainTaskScheduler(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public const string AutoCancelOrdersJobName = "AutoCancelOrders";


        public void Reschedule(AutoCancelOrdersDomainTask domainTask)
        {
            var dto = mapper.Map<AutoCancelOrdersDomainTask, AutoCancelOrdersDomainTaskDto>(domainTask);

            RecurringJob.AddOrUpdate<AutoCancelOrdersJob>(AutoCancelOrdersJobName,x=>x.Execute(dto),ToCron(domainTask.AutoCancellationHour));
        }

        private string ToCron(AutoCancellationHour autoCancellationHour)
        {
            return Cron.Daily(autoCancellationHour);
        }
    }
}
