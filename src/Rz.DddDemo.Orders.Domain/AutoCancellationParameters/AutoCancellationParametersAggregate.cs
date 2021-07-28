using Rz.DddDemo.Base.Domain.DomainEntity;
using Rz.DddDemo.Orders.Domain.AutoCancellationParameters.DomainEvents;
using Rz.DddDemo.Orders.Domain.AutoCancellationParameters.ValueObjects;

namespace Rz.DddDemo.Orders.Domain.AutoCancellationParameters
{
    public class AutoCancellationParametersAggregate:SingletonDomainEntityBase
    {
        public event DomainEventHanlder<AutoCancellationEvaluationHourChangedDomainEvent>
            AutoCancellationEvaluationHourChanged;

        public AutoCancellationHour AutoCancellationHour { get; private set; }

        public TimeUntilAutoCancellationInHours TimeUntilAutoCancellationInHours { get; private set; }

        public void Update(AutoCancellationHour newAutoCancellationHour,
            TimeUntilAutoCancellationInHours newTimeUntilAutoCancellationInHours)
        {
            if (AutoCancellationHour != newAutoCancellationHour)
            {
                AutoCancellationHour = newAutoCancellationHour;
                AutoCancellationEvaluationHourChanged?.Invoke(new AutoCancellationEvaluationHourChangedDomainEvent());
            }
            
            TimeUntilAutoCancellationInHours = newTimeUntilAutoCancellationInHours;
        }
    }
}
