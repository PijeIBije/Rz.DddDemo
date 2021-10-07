using System;
using Rz.DddDemo.Base.Domain.ValueObject;

namespace Rz.DddDemo.Reservations.Domain.Performance
{
    public class PerformanceId:GuidValueObjectBase
    {
        public PerformanceId(Guid value)
        {
            
        }

        public PerformanceId()
        {
            
        }

        public static implicit operator PerformanceId(Guid value) => new PerformanceId(value);
    }
}
