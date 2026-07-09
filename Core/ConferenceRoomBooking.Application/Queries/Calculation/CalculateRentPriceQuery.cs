namespace ConferenceRoomBooking.Application.Queries.Calculation
{
    public class CalculateRentPriceQuery
    {
        public DateTime StartAt { get; set; }
        public TimeSpan DurationHours { get; set; }
        public decimal BaseHourPrice { get; set; }
    }
}
