using ConferenceRoomBooking.Domain.Entities;

namespace ConferenceRoomBooking.Application.Interfaces.Repositories
{
    public interface IBookingRepository
    {
        Task AddAsync(
        BookingEntity bookingEntity,
        CancellationToken cancellationToken);
    }
}
