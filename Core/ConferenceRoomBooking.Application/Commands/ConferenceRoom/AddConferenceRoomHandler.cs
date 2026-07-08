using ConferenceRoomBooking.Application.Interfaces.Repositories;
using ConferenceRoomBooking.Application.Interfaces.Sevices;
using ConferenceRoomBooking.Domain.Entities;

namespace ConferenceRoomBooking.Application.Commands.ConferenceRoom
{
    public class AddConferenceRoomHandler : IRequestHendler<AddConferenceRoomCommand>
    {
        private readonly IConferenceRoomRepository _repository;

        public AddConferenceRoomHandler(IConferenceRoomRepository repository)
        {
            _repository = repository;
        }

        public async Task HendlerAsync(AddConferenceRoomCommand request, CancellationToken cancellationToken = default)
        {
            await _repository.AddAsync(new ConferenceRoomEntity
            {
                Name = request.Name,
                Capacity = request.Capacity,
                BaseHourPrice = request.BasePrice,
                //UpdateAt = DateTime.UtcNow,
                //IsDeleted = false,
                //BookingId = Guid.NewGuid(),
                //Booking = new BookingEntity
                //{
                //    StartDate = DateTime.UtcNow,
                //    EndDate = DateTime.UtcNow.AddHours(1),
                //    IsDeleted = false,
                //    UpdateAt = DateTime.UtcNow
                //}

            }, cancellationToken);
        }
    }
}
