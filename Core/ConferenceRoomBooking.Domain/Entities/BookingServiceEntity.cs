namespace ConferenceRoomBooking.Domain.Entities
{
    public class BookingServiceEntity
    {
        public Guid BookingId { get; set; }

        public BookingEntity BookingEntity { get; set; } = null!;

        public Guid OptionalServiceId { get; set; }

        public OptionalServiceEntity OptionalServiceEntity { get; set; } = null!;
    }
}
