using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rz.DddDemo.Repertory.Domain.Performance;

namespace Rz.DddDemo.Repertory.Application.Interfaces
{
    public interface IPerformanceRepository
    {
        Task Save(PerformanceAggregate performanceAggregate);
    }
}
