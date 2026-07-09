namespace ConferenceRoomBooking.Application.DTOs.Requests.Booking
{
    public class AddBookingRequest
    {
        public Guid ConferenceRoomId { get; set; }
        public DateTime StartAt { get; set; }
        public TimeSpan DurationHours { get; set; }
        public IEnumerable<Guid> ServiceIds { get; set; } = Enumerable.Empty<Guid>();
    }
}
