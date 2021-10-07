using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rz.DddDemo.Base.Domain;

namespace Rz.DddDemo.Repertory.Domain.Auditorium
{
    public class Row
    {
        public SeatNumber SeatNumberStart { get; }

        public SeatNumber SeatNumberEnd { get; }

        public RowNumber RowNumber { get; }

        public Row(SeatNumber seatNumberStart, SeatNumber seatNumberEnd, RowNumber rowNumber)
        {
            Guard.AgainstNullValues((new (object value, string parameterName)[]
            {
                (seatNumberStart,nameof(seatNumberStart)),
                (rowNumber,nameof(rowNumber))
            }));

            SeatNumberStart = seatNumberStart;
            SeatNumberEnd = seatNumberEnd;
            RowNumber = rowNumber;
        }
    }
}
