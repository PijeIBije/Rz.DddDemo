using Microsoft.EntityFrameworkCore;
using Rz.DddDemo.Reservations.Infrastructure.Schemas.Database.Sql.Dtos;

namespace Rz.DddDemo.Reservations.Infrastructure.Schemas.Database.Sql
{
    public class ReservationsDbContext:DbContext
    {
        public DbSet<CustomerDto> Customers { get; set; }

        public DbSet<ReservationDto> Reservations { get; set; }

        public DbSet<SeatDto> Seats { get; set; }

        public DbSet<SeatPriceDto> SeatPrices { get; set; }

        public DbSet<TicketDto> Tickets { get; set; }

        public DbSet<PerformanceDto> Performances { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SeatDto>()
                .HasKey(entity=>new { entity.SeatNumber, entity.RowNumber, entity.PerformanceId});

            modelBuilder.Entity<SeatPriceDto>()
                .HasKey(entity => new {entity.Name, entity.SeatNumber, entity.RowNumber, entity.PerformanceId});

            modelBuilder.Entity<CustomerDto>()
                .HasKey(entity => entity.Id);

            modelBuilder.Entity<ReservationDto>()
                .HasKey(entity => entity.Id);

            modelBuilder.Entity<TicketDto>()
                .HasKey(entity => entity.Id);
        }
    
    }
}
