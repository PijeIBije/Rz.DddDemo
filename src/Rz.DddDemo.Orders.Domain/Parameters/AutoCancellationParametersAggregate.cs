using System;
using System.Collections.Generic;
using System.Text;
using Rz.DddDemo.Base.Domain.DomainEntity;
using Rz.DddDemo.Orders.Domain.Parameters.DomainEvents;
using Rz.DddDemo.Orders.Domain.Parameters.ValueObjects;

namespace Rz.DddDemo.Orders.Domain.Parameters
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
