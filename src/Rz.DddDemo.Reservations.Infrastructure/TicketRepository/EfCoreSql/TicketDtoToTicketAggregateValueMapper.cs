using System;
using System.Collections.Generic;
using Rz.DddDemo.Base.Mapping.Interface;
using Rz.DddDemo.Reservations.Domain.Performance;
using Rz.DddDemo.Reservations.Domain.Ticket;
using Rz.DddDemo.Reservations.Infrastructure.Schemas.Database.Sql.Dtos;

namespace Rz.DddDemo.Reservations.Infrastructure.TicketRepository.EfCoreSql
{
    public class TicketDtoToTicketAggregateValueMapper : IValueMapping
    {
        public bool TryMap(object source, Type resultType, out object result, bool allowPartialMapping, IMapper mainMapper)
        {
            if (resultType != typeof(TicketAggregate) || !(source is TicketDto))
            {
                result = default;
                return false;
            }

            var ticketDto = (TicketDto) source;

            var ticket = new TicketAggregate(
                ticketDto.Id,
                ticketDto.CustomerId,
                ticketDto.PerformanceId,
                new SeatId(ticketDto.RowNumber,ticketDto.SeatNumber),
                ticketDto.PriceName,
                ticketDto.Price,
                ticketDto.Returned);

            result = ticket;
            return true;
        }
    }
}
