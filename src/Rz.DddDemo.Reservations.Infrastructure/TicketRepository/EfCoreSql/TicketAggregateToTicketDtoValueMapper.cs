using System;
using System.Collections.Generic;
using Rz.DddDemo.Base.Mapping.Interface;
using Rz.DddDemo.Reservations.Domain.Performance;
using Rz.DddDemo.Reservations.Domain.Ticket;
using Rz.DddDemo.Reservations.Infrastructure.Schemas.Database.Sql.Dtos;

namespace Rz.DddDemo.Reservations.Infrastructure.TicketRepository.EfCoreSql
{
    public class TicketAggregateToTicketDtoValueMapper:IValueMapping
    {
        public bool TryMap(object source, Type resultType, out object result, bool allowPartialMapping, IMapper mainMapper)
        {
            if (resultType != typeof(TicketDto) || !(source is TicketAggregate))
            {
                result = default;
                return false;
            }

            var ticket = (TicketAggregate) source;

            var ticketDto = mainMapper.Map<TicketAggregate, TicketDto>(ticket);

            ticketDto.RowNumber = ticket.SeatId.RowNumber;
            ticketDto.SeatNumber = ticket.SeatId.SeatNumber;

            result = ticketDto;
            return true;
        }
    }
}
