using ConferenceRoomBooking.Application.Interfaces.Repositories;
using ConferenceRoomBooking.Application.Interfaces.Sevices;
using ConferenceRoomBooking.Domain.Entities;

namespace ConferenceRoomBooking.Application.Queries.ConferenceRoom
{
    public class GetByIdConferenceRoomsHandler : IRequestHendler<GetByIdConferenceRoomsQuery, ConferenceRoomEntity>
    {
        private readonly IConferenceRoomRepository _repository;

        public GetByIdConferenceRoomsHandler(IConferenceRoomRepository repository)
        {
            _repository = repository;
        }
        public async Task<ConferenceRoomEntity> HendlerAsync(GetByIdConferenceRoomsQuery request, CancellationToken cancellationToken = default)
        {
            return await _repository.GetByIdRoomsAsync(request.Id, cancellationToken);
        }
    }
}
