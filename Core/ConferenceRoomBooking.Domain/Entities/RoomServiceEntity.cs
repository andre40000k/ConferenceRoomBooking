namespace ConferenceRoomBooking.Domain.Entities
{
    public class RoomServiceEntity
    {
        public Guid ConferenceRoomId { get; set; }

        public ConferenceRoomEntity ConferenceRoom { get; set; } = null!;

        public Guid OptionalServiceId { get; set; }

        public OptionalServiceEntity OptionalService { get; set; } = null!;
    }
}
