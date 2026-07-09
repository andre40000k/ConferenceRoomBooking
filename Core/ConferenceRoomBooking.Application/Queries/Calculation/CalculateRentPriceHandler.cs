using ConferenceRoomBooking.Application.Interfaces.Repositories;
using ConferenceRoomBooking.Application.Interfaces.Sevices;

namespace ConferenceRoomBooking.Application.Queries.Calculation
{
    public class CalculateRentPriceHandler : IRequestHandler<CalculateRentPriceQuery, decimal>
    {
        private readonly ICalculateRentRepository _repository;

        public CalculateRentPriceHandler(ICalculateRentRepository repository)
        {
            _repository = repository;
        }

        public async Task<decimal> HandlerAsync(CalculateRentPriceQuery request, CancellationToken cancellationToken = default)
        {
            var rules = await _repository.GetRulesAsync(cancellationToken);

            decimal total = 0;

            var current = request.StartAt;
            var end = request.StartAt.Add(request.DurationHours);

            while (current < end)
            {
                var next = current.AddHours(1);

                if (next > end)
                    next = end;

                var rule = rules.FirstOrDefault(r =>
                    current.TimeOfDay >= r.Start &&
                    current.TimeOfDay < r.End);

                var modifier = rule?.Modifier ?? 0;

                total += request.BaseHourPrice *
                         (1 + modifier / 100m) *
                         (decimal)(next - current).TotalHours;

                current = next;
            }

            return total;
        }
    }
}
