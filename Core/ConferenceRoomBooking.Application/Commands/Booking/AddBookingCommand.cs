namespace ConferenceRoomBooking.Application.Commands.Booking
{
    public class AddBookingCommand
    {
        public Guid ConferenceRoomId { get; set; }
        public DateTime StartAt { get; set; }
        public TimeSpan DurationHours { get; set; }
        public IEnumerable<Guid> ServiceIds { get; set; } = Enumerable.Empty<Guid>();
    }
}
