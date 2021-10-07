using System;
using System.Collections.Generic;
using System.Text;
using Rz.DddDemo.Base.Domain.ValueObject;

namespace Rz.DddDemo.Reservations.Domain.Reservation
{
    public class ReservationStatus:EnumValueObjectBase<ReservationStatus.Values>
    {
        public enum Values
        {
            Cancelled,
            Created,
            Fulfilled,
            Expired
        }

        public ReservationStatus(Values value) : base(value)
        {
        }

        public ReservationStatus(string value) : base(value)
        {
        }

        public static implicit operator ReservationStatus(Values value) => new ReservationStatus(value);
    }
}
