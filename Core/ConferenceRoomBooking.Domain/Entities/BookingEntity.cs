namespace ConferenceRoomBooking.Domain.Entities
{
    public class BookingEntity : BaseEntity
    {
        public DateTime StartAt { get; set; }
        public TimeSpan Duration { get; set; }
        public DateTime EndAt { get; set; }
        public decimal TotalPrice { get; set; }
        public byte Status { get; set; }

        //public IEnumerable<ConferenceRoom> ConferenceRooms { get; set; }
    }
}
