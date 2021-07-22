using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Rz.DddDemo.Base.Mapping.Interface;
using Rz.DddDemo.Orders.Application.DomainTasks.Order;

namespace Rz.DddDemo.Orders.Infrastructure.AutoCancelOrdersDomainTaskSchedule.HangFire
{
    public class AutoCancelOrdersJob
    {
        private readonly AutoCancelOrdersDomainTaskHandler domainTaskHandler;
        private readonly IMapper mapper;


        public AutoCancelOrdersJob(
            AutoCancelOrdersDomainTaskHandler domainTaskHandler,
            IMapper mapper)
        {
            this.domainTaskHandler = domainTaskHandler;
            this.mapper = mapper;
        }


        public async Task Execute(AutoCancelOrdersDomainTaskDto autoCancelOrdersDomainTaskDto)
        {
            var domainTask = mapper.Map<AutoCancelOrdersDomainTaskDto, AutoCancelOrdersDomainTask>(autoCancelOrdersDomainTaskDto);

            await domainTaskHandler.Handle(domainTask);
        }
    }
}
