using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rz.DddDemo.Base.Domain.ValueObject;

namespace Rz.DddDemo.Repertory.Domain.Performance
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
