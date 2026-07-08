namespace ConferenceRoomBooking.Application.DTOs.Requests.ConferenceRoom
{
    public class UpsertConferenceRoomRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public decimal BasePrice { get; set; }
    }
}
