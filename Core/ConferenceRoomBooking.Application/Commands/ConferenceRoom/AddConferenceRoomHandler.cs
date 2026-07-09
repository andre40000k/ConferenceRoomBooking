using ConferenceRoomBooking.Application.DTOs.Responses.ConferenceRoom;
using ConferenceRoomBooking.Application.Interfaces.Repositories;
using ConferenceRoomBooking.Application.Interfaces.Sevices;
using ConferenceRoomBooking.Domain.Entities;

namespace ConferenceRoomBooking.Application.Commands.ConferenceRoom
{
    public class AddConferenceRoomHandler : IRequestHandler<AddConferenceRoomCommand, AddConferenceRoomResponse>
    {
        private readonly IConferenceRoomRepository _repository;

        public AddConferenceRoomHandler(IConferenceRoomRepository repository)
        {
            _repository = repository;
        }

        public async Task<AddConferenceRoomResponse> HandlerAsync(AddConferenceRoomCommand request, CancellationToken cancellationToken = default)
        {
            return await _repository.AddAsync(new ConferenceRoomEntity
            {
                Name = request.Name,
                Capacity = request.Capacity,
                BaseHourPrice = request.BasePrice

            }, cancellationToken);
        }
    }
}
