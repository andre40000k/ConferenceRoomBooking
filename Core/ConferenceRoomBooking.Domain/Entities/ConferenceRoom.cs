namespace ConferenceRoomBooking.Domain.Entities
{
    public class ConferenceRoom : BaseEntity
    {
        public Guid BookingId { get; set; }
        public Booking Booking { get; set; }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public decimal BasePrice { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime UpdateAt { get; set; }

        //public IEnumerable<Service> Services { get; set; }
    }
}
