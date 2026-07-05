using ConferenceRoomBooking.Domain.Entities;

namespace ConferenceRoomBooking.Domain.Interfaces.DbContext
{
    public interface IReadConferenceRoomBookingContext
    {
        IQueryable<Booking> Bookings { get; }
        IQueryable<ConferenceRoom> ConferenceRooms {  get; }
        IQueryable<Service> Services { get; }
    }
}
