using ConferenceRoomBooking.Application.Interfaces.Repositories;
using ConferenceRoomBooking.Application.Interfaces.Sevices;
using ConferenceRoomBooking.Domain.Entities;

namespace ConferenceRoomBooking.Application.Commands.Service
{
    public class AddServiceHandler : IRequestHandler<UpsertServiceCommand>
    {
        private readonly IOptionalServiceRepository _repository;
        public AddServiceHandler(IOptionalServiceRepository repository) 
        {
            _repository = repository;
        }
        public async Task HandlerAsync(UpsertServiceCommand request, CancellationToken cancellationToken = default)
        {
            await _repository.AddAsync(new OptionalServiceEntity
            {
                Name = request.Name,
                ServicePrice = request.Price
            }, cancellationToken);
        }
    }
}
