using System;
using System.Collections.Generic;
using System.Text;
using Rz.DddDemo.Base.Domain.ValueObject;
using Rz.DddDemo.Base.Domain.ValueObject.Interfaces;

namespace Rz.DddDemo.Reservations.Domain.Performance
{
    public class SeatId:IValueObject
    {
        public RowNumber RowNumber { get; }
        public SeatNumber SeatNumber { get; }

        public SeatId(RowNumber rowNumber, SeatNumber seatNumber)
        {
            RowNumber = rowNumber;
            SeatNumber = seatNumber;
        }
    }
}
