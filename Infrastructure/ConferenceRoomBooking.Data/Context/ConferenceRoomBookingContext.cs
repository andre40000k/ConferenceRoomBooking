using ConferenceRoomBooking.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ConferenceRoomBooking.Data.Context
{
    public class ConferenceRoomBookingContext : DbContext
    {
        public ConferenceRoomBookingContext(DbContextOptions<ConferenceRoomBookingContext> options):base(options) { }

        public DbSet<BookingEntity> Bookings {  get; set; }

        public DbSet<ConferenceRoomEntity> ConferenceRooms { get; set; }

        public DbSet<OptionalServiceEntity> OptionalServices { get; set; }

        public DbSet<BookingServiceEntity> BookingServices { get; set; }

        public DbSet<RoomServiceEntity> RoomServiceEntities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ConferenceRoomBookingContext).Assembly);
        }
    }
}
