namespace ConferenceRoomBooking.Application.Queries.ConferenceRoom
{
    public class GetAvailableConferenceRoomsQuery
    {
        public DateTime StartDateTime { get; set; }

        public TimeSpan DurationHours { get; set; }

        public int Capacity { get; set; }
    }
}
