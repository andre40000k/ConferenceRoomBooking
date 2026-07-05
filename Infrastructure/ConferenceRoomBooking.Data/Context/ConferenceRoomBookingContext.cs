using ConferenceRoomBooking.Domain.Entities;
using ConferenceRoomBooking.Domain.Interfaces.DbContext;
using Microsoft.EntityFrameworkCore;

namespace ConferenceRoomBooking.Data.Context
{
    public class ConferenceRoomBookingContext : DbContext, IReadConferenceRoomBookingContext, IWriteConferenceRoomBookingContext
    {
        public ConferenceRoomBookingContext(DbContextOptions<ConferenceRoomBookingContext> options):base(options) { }

        public DbSet<Booking> Bookings => Set<Booking>();

        public DbSet<ConferenceRoom> ConferenceRooms => Set<ConferenceRoom>();

        public DbSet<Service> Services => Set<Service>();

        IQueryable<Booking> IReadConferenceRoomBookingContext.Bookings => Bookings;

        IQueryable<ConferenceRoom> IReadConferenceRoomBookingContext.ConferenceRooms => ConferenceRooms;

        IQueryable<Service> IReadConferenceRoomBookingContext.Services => Services;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ConferenceRoomBookingContext).Assembly);
        }

        Task<int> IWriteConferenceRoomBookingContext.SaveChangesAsync(CancellationToken ct)
        => SaveChangesAsync(ct);
    }
}
