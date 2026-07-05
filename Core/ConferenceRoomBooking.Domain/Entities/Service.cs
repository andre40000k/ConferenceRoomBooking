namespace ConferenceRoomBooking.Domain.Entities
{
    public class Service : BaseEntity
    {
        public Guid ConferenceRoomId { get; set; }
        public ConferenceRoom ConferenceRoom { get; set; }

        public string Name { get; set; }
        public decimal ServicePrice { get; set; }
        public bool IsDeleted { get; set; }
    }
}
