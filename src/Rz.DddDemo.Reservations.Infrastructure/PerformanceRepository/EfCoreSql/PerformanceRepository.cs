using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Rz.DddDemo.Base.Application.TransactionHandling.Interfaces;
using Rz.DddDemo.Base.Infrastructure.EntityFramework;
using Rz.DddDemo.Base.Infrastructure.Exceptions;
using Rz.DddDemo.Base.Mapping.Interface;
using Rz.DddDemo.Reservations.Application.Interfaces;
using Rz.DddDemo.Reservations.Domain.Performance;
using Rz.DddDemo.Reservations.Domain.Reservation;
using Rz.DddDemo.Reservations.Infrastructure.Schemas.Database.Sql;
using Rz.DddDemo.Reservations.Infrastructure.Schemas.Database.Sql.Dtos;

namespace Rz.DddDemo.Reservations.Infrastructure.PerformanceRepository.EfCoreSql
{
    public class PerformanceRepository: EfRepositoryBase<ReservationsDbContext>, IPerformanceRepository
    {
        private readonly IMapper mapper;

        public PerformanceRepository(IMapper mapper, IDbContextFactory<ReservationsDbContext> dbContextFactory,
            ITransactionEvents transactionEvents) : base(dbContextFactory, transactionEvents)
        {
            this.mapper = mapper;
        }

        public async Task<PerformanceAggregate> GetById(PerformanceId performanceId)
        {
            var performanceDto = await DbContext.Performances.SingleOrDefaultAsync();

            if (performanceDto == null) throw new NoResultsException(typeof(PerformanceAggregate), performanceId);

            var perfomance = mapper.Map<PerformanceDto, PerformanceAggregate>(performanceDto);

            return perfomance;
        }

        public async Task<bool> SeatsFree(PerformanceId performanceId, IEnumerable<SeatId> seatIds)
        {
            var performanceExists = await DbContext.Performances.AnyAsync(x => x.Id == performanceId.Value);

            if(!performanceExists) throw new NoResultsException(typeof(PerformanceAggregate),performanceId);

            var seatsSoldOrReserved = await DbContext.Seats.AnyAsync(seat =>
                seat.PerformanceId == performanceId.Value &&
                seat.Tickets.Any(ticket => !ticket.Returned) && seat.Reservations.Any(reservation =>
                    reservation.Status != ReservationStatus.Values.Cancelled.ToString()));

            return seatsSoldOrReserved;
        }
    }
}
