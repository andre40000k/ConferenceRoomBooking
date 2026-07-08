namespace ConferenceRoomBooking.Application.Commands.ConferenceRoom
{
    public class UpsertConferenceRoomCommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public decimal BasePrice { get; set; }
    }
}
