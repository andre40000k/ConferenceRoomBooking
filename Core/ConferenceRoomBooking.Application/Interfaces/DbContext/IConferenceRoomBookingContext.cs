using ConferenceRoomBooking.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ConferenceRoomBooking.Domain.Interfaces.DbContext
{
    public interface IConferenceRoomBookingContext
    {
        DbSet<Booking> Bookings { get; set; }

        DbSet<ConferenceRoom> ConferenceRooms { get; set; }

        DbSet<OptionalService> OptionalServices { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
