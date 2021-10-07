using System;
using System.Collections.Generic;
using System.Runtime;
using System.Text;

namespace Rz.DddDemo.Reservations.Infrastructure.Schemas.Database.Sql.Dtos
{
    public class SeatPriceDto
    {
        public int SeatNumber { get; set; }

        public int RowNumber { get; set; }

        public Guid PerformanceId { get; set; }

        public decimal Price { get; set; }

        public string Name { get; set; }

        public SeatDto Seat { get; set; }
    }
}
