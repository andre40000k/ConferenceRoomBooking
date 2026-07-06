using ConferenceRoomBooking.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ConferenceRoomBooking.Domain.Interfaces.DbContext
{
    public interface IConferenceRoomBookingContext
    {
        DbSet<Booking> Bookings { get; set; }

        DbSet<ConferenceRoom> ConferenceRooms { get; set; }

        DbSet<Service> Services { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
