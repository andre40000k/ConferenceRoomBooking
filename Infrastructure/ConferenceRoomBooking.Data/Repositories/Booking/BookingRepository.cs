using ConferenceRoomBooking.Application.Interfaces.Repositories;
using ConferenceRoomBooking.Data.Context;
using ConferenceRoomBooking.Domain.Entities;

namespace ConferenceRoomBooking.Data.Repositories.Booking
{
    public class BookingRepository : IBookingRepository
    {
        private readonly ConferenceRoomBookingContext _db;

        public BookingRepository(ConferenceRoomBookingContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db)); ;
        }
        public async Task AddAsync(BookingEntity bookingEntity, CancellationToken cancellationToken)
        {
            _db.Bookings.Add(bookingEntity);
            await _db.SaveChangesAsync(cancellationToken);
        }
    }
}
