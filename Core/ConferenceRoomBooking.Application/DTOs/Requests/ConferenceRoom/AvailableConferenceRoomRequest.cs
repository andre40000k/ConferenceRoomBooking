namespace ConferenceRoomBooking.Application.DTOs.Requests.ConferenceRoom
{
    public class AvailableConferenceRoomRequest
    {
        public DateTime StartAt { get; set; }
        public TimeSpan DurationHours { get; set; } 
        public int Capacity { get; set; }
    }
}
