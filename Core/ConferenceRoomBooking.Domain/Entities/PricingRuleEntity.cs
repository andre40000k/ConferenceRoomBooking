namespace ConferenceRoomBooking.Domain.Entities
{
    public class PricingRuleEntity
    {
        public string Name { get; set; } = string.Empty;
        public TimeSpan Start { get; set; }
        public TimeSpan End { get; set; }
        public decimal Modifier { get; set; }
    }
}
