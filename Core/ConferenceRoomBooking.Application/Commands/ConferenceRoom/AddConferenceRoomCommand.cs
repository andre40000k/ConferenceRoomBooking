namespace ConferenceRoomBooking.Application.Commands.ConferenceRoom
{
    public class AddConferenceRoomCommand
    {
        public string Name { get; set; }
        public int Capacity { get; set; }
        public decimal BasePrice { get; set; }
    }
}
