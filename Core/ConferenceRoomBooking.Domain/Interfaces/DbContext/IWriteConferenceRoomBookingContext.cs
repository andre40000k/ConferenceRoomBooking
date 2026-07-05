using ConferenceRoomBooking.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ConferenceRoomBooking.Domain.Interfaces.DbContext
{
    public interface IWriteConferenceRoomBookingContext
    {
        DbSet<Booking> Bookings { get;}
        DbSet<ConferenceRoom> ConferenceRooms { get; }
        DbSet<Service> Services { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
