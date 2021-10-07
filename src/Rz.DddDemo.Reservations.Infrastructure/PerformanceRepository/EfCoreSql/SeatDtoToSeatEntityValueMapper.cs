using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rz.DddDemo.Base.Mapping.Interface;
using Rz.DddDemo.Reservations.Domain.Performance;
using Rz.DddDemo.Reservations.Infrastructure.Schemas.Database.Sql.Dtos;

namespace Rz.DddDemo.Reservations.Infrastructure.PerformanceRepository.EfCoreSql
{
    public class SeatDtoToSeatEntityValueMapper : IValueMapping
    {
        public bool TryMap(object source, Type resultType, out object result, bool allowPartialMapping, IMapper mainMapper)
        {
            if (resultType != typeof(SeatEntity) || !(source is SeatDto))
            {
                result = default;
                return false;
            }

            var seatDto = (SeatDto) source;

            var subMappingSuccesful =
                mainMapper.TryMap<IEnumerable<SeatPriceDto>, IEnumerable<SeatPriceEntity>>(seatDto.Prices,
                    out IEnumerable<SeatPriceEntity> seatPrices);

            if (!subMappingSuccesful)
            {
                result = default;
                return false;
            }

            var seatEntity = new SeatEntity(new SeatId(seatDto.RowNumber, seatDto.SeatNumber),seatPrices);

            result = seatEntity;
            return true;
        }
    }
}
