using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rz.DddDemo.Reservations.Domain.Performance;

namespace Rz.DddDemo.Reservations.Application.Interfaces
{
    public interface IPerformanceRepository
    {
        Task<PerformanceAggregate> GetById(PerformanceId performanceId);

        Task<bool> SeatsFree(PerformanceId performanceId, IEnumerable<SeatId> seatIds);
    }
}
