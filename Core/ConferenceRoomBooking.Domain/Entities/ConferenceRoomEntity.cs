namespace ConferenceRoomBooking.Domain.Entities
{
    public class ConferenceRoomEntity : BaseEntity
    {
        public string Name { get; set; }
        public int Capacity { get; set; }
        public decimal BaseHourPrice { get; set; }
        public ICollection<RoomServiceEntity> RoomServices { get; set; } = [];

        public ICollection<BookingEntity> BookingEntitys { get; set; } = [];
    }
}
