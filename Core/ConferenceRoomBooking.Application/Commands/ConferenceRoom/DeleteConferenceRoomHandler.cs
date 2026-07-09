using ConferenceRoomBooking.Application.Interfaces.Repositories;
using ConferenceRoomBooking.Application.Interfaces.Sevices;

namespace ConferenceRoomBooking.Application.Commands.ConferenceRoom
{
    public class DeleteConferenceRoomHandler : IRequestHandler<DeleteConferenceRoomCommand, int>
    {
        private readonly IConferenceRoomRepository _repository;

        public DeleteConferenceRoomHandler(IConferenceRoomRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> HandlerAsync(DeleteConferenceRoomCommand requestId, CancellationToken cancellationToken = default)
        {
           return await _repository.DeletedAsync(requestId.Id, cancellationToken);
        }
    }
}
