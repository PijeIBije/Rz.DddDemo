using Rz.DddDemo.Base.Application.DomainTaskHandling.Interfaces;

namespace Rz.DddDemo.Reservations.Application.DomainTasks.Order
{
    public class AutoCancelOrdersDomainTask:IDomainTask
    {
        public AutoCancellationHour AutoCancellationHour { get; set; }
    }
}
