using ConferenceRoomBooking.Application.Interfaces.Repositories;
using ConferenceRoomBooking.Application.Interfaces.Sevices;

namespace ConferenceRoomBooking.Application.Commands.ConferenceRoom
{
    public class UpsertConferenceRoomHandler : IRequestHandler<UpsertConferenceRoomCommand>
    {
        private readonly IConferenceRoomRepository _repository;


        public UpsertConferenceRoomHandler(IConferenceRoomRepository repository)
        {
            _repository = repository;
        }
        public async Task HandlerAsync(UpsertConferenceRoomCommand requestConferenceRoom, CancellationToken cancellationToken = default)
        {
            await _repository.UpdateAsync(
            requestConferenceRoom.Id,
            requestConferenceRoom.Name,
            requestConferenceRoom.Capacity,
            requestConferenceRoom.BasePrice,
            cancellationToken);
        }
    }
}
