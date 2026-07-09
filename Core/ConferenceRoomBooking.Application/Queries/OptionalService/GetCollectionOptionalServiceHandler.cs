using ConferenceRoomBooking.Application.Interfaces.Repositories;
using ConferenceRoomBooking.Application.Interfaces.Sevices;
using ConferenceRoomBooking.Domain.Entities;

namespace ConferenceRoomBooking.Application.Queries.OptionalService
{
    public class GetCollectionOptionalServiceHandler : IRequestHendler<GetCollectionOptionalServiceQuery, IEnumerable<OptionalServiceEntity>>
    {
        private readonly IOptionalServiceRepository _repository;
        public GetCollectionOptionalServiceHandler(IOptionalServiceRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<OptionalServiceEntity>> HendlerAsync(GetCollectionOptionalServiceQuery request, CancellationToken cancellationToken = default)
        {
            return await _repository.GetCollectionSirviceAsync(request, cancellationToken);
        }
    }
}
