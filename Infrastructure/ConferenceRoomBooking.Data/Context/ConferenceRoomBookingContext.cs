using ConferenceRoomBooking.Domain.Entities;
using ConferenceRoomBooking.Domain.Interfaces.DbContext;
using Microsoft.EntityFrameworkCore;

namespace ConferenceRoomBooking.Data.Context
{
    public class ConferenceRoomBookingContext : DbContext, IConferenceRoomBookingContext
    {
        public ConferenceRoomBookingContext(DbContextOptions<ConferenceRoomBookingContext> options):base(options) { }

        public DbSet<Booking> Bookings {  get; set; }

        public DbSet<ConferenceRoom> ConferenceRooms { get; set; }

        public DbSet<Service> Services { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ConferenceRoomBookingContext).Assembly);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
