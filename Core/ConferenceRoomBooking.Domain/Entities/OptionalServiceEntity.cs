namespace ConferenceRoomBooking.Domain.Entities
{
    public class OptionalServiceEntity : BaseEntity
    {
        public string Name { get; set; }
        public decimal ServicePrice { get; set; }
        public ICollection<RoomServiceEntity> RoomServices { get; set; } = [];

        public ICollection<BookingServiceEntity> BookingServices { get; set; } = [];
    }
}
