namespace ConferenceRoomBooking.Domain.Entities
{
    public class BookingEntity : BaseEntity
    {
        public Guid ConferenceRoomId { get; set; }
        public ConferenceRoomEntity ConferenceRoomEntity { get; set; } = null!;

        public DateTime StartAt { get; set; }
        public TimeSpan DurationHours { get; set; }
        public decimal TotalPrice { get; set; }
        public byte Status { get; set; }

        public ICollection<BookingServiceEntity> BookingServices { get; set; } = [];
    }
}
