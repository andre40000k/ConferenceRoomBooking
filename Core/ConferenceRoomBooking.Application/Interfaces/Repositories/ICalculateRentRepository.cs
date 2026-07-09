using ConferenceRoomBooking.Domain.Entities;

namespace ConferenceRoomBooking.Application.Interfaces.Repositories
{
    public interface ICalculateRentRepository
    {
        Task<ICollection<PricingRuleEntity>> GetRulesAsync(CancellationToken cancellationToken);
    }
}
