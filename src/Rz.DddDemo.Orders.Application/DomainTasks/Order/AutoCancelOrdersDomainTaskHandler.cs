using System;
using System.Linq;
using System.Threading.Tasks;
using Rz.DddDemo.Base.Application.DomainEventHandling;
using Rz.DddDemo.Base.Application.DomainTaskHandling;
using Rz.DddDemo.Base.Application.IntegrationEventHandling;
using Rz.DddDemo.Base.Application.TransactionHandling;
using Rz.DddDemo.Orders.Application.Interfaces;

namespace Rz.DddDemo.Orders.Application.DomainTasks.Order
{
    public class AutoCancelOrdersDomainTaskHandler:DomainTaskHandlerBase<AutoCancelOrdersDomainTask>
    {
        private readonly IOrderRepository orderRepository;
        private readonly IAutoCancellationParametersRepository autoCancellationParametersRepository;

        public AutoCancelOrdersDomainTaskHandler(
            IOrderRepository orderRepository,
            IAutoCancellationParametersRepository autoCancellationParametersRepository,
            DomainEventsHandler domainEventsHandler,
            IntegrationEventsPublisher integrationEventsPublisher, 
            Transaction transaction) : base(domainEventsHandler, integrationEventsPublisher, transaction)
        {
            this.orderRepository = orderRepository;
            this.autoCancellationParametersRepository = autoCancellationParametersRepository;
        }

        protected override async Task HandleBody(AutoCancelOrdersDomainTask command)
        {
            var autoCancellationParameters = await autoCancellationParametersRepository.Get();

            var createDateForCancellation = DateTime.Now -
                                            new TimeSpan(0, autoCancellationParameters.TimeUntilAutoCancellationInHours,
                                                0, 0);

            var ordersToCancell = (await orderRepository.GetUnpaidWithCreateDateEarlierThan(createDateForCancellation)).ToList();

            foreach (var orderToCancel in ordersToCancell)
            {
                orderToCancel.Cancel();
            }

            await orderRepository.Save(ordersToCancell);
        }
    }
}
