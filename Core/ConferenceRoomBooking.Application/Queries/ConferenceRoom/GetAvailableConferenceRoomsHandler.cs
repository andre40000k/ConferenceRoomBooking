using ConferenceRoomBooking.Application.DTOs.Responses.ConferenceRoom;
using ConferenceRoomBooking.Application.Interfaces.Repositories;
using ConferenceRoomBooking.Application.Interfaces.Sevices;

namespace ConferenceRoomBooking.Application.Queries.ConferenceRoom
{
    public class GetAvailableConferenceRoomsHandler : IRequestHendler<GetAvailableConferenceRoomsQuery, IEnumerable<AvailableConferenceRoomRespons>>
    {
        private readonly IConferenceRoomRepository _repository;

        public GetAvailableConferenceRoomsHandler(IConferenceRoomRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<AvailableConferenceRoomRespons>> HendlerAsync(GetAvailableConferenceRoomsQuery request, CancellationToken cancellationToken = default)
        {
            return await _repository.GetAvailableRoomsAsync(
                request.StartDateTime,
                request.DurationHours,
                request.Capacity,
                cancellationToken);
        }
    }
}
