namespace ConferenceRoomBooking.Application.DTOs.Responses.ConferenceRoom
{
    public class AvailableConferenceRoomRespons
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public int Capacity { get; set; }

        public decimal BaseHourPrice { get; set; }
    }
}
