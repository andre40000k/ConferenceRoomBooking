namespace ConferenceRoomBooking.Application.DTOs.Requests.ConferenceRoom
{
    public class AddConferenceRoomRequest
    {
        public string Name { get; set; }
        public int Capacity { get; set; }
        public decimal BasePrice { get; set; }
    }
}
