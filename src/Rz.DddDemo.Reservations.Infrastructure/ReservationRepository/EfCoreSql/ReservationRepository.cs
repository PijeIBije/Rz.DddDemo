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
using Rz.DddDemo.Reservations.Domain.Reservation;
using Rz.DddDemo.Reservations.Infrastructure.Schemas.Database.Sql;
using Rz.DddDemo.Reservations.Infrastructure.Schemas.Database.Sql.Dtos;

namespace Rz.DddDemo.Reservations.Infrastructure.ReservationRepository.EfCoreSql
{
    public class ReservationRepository:EfRepositoryBase<ReservationsDbContext>,IReservationRepository
    {
        private readonly IMapper mapper;

        public ReservationRepository(
            IMapper mapper,
            IDbContextFactory<ReservationsDbContext> dbContextFactory, 
            ITransactionEvents transactionEvents) : base(dbContextFactory, transactionEvents)
        {
            this.mapper = mapper;
        }

        public Task Save(ReservationAggregate reservation)
        {
            var reservationDto = mapper.Map<ReservationAggregate, ReservationDto>(reservation);

            DbContext.Reservations.Update(reservationDto);

            var seats = 

            return Task.CompletedTask;
        }

        public async Task<ReservationAggregate> GetById(ReservationId reservationId)
        {
            var reservationDto = await DbContext.Reservations.SingleOrDefaultAsync(x => x.Id == reservationId.Value);

            if(reservationDto == null) throw new NoResultsException(typeof(ReservationAggregate),reservationId);

            var reservation = mapper.Map<ReservationDto, ReservationAggregate>(reservationDto);

            return reservation;
        }
    }
}
