using ConferenceRoomBooking.Application.Interfaces.Repositories;
using ConferenceRoomBooking.Application.Interfaces.Sevices;
using ConferenceRoomBooking.Application.Queries.ConferenceRoom;
using ConferenceRoomBooking.Application.Queries.OptionalService;
using ConferenceRoomBooking.Domain.Entities;

namespace ConferenceRoomBooking.Application.Commands.Booking
{
    public class AddBookingHandler : IRequestHendler<AddBookingCommand>
    {
        private readonly IBookingRepository _repository;
        private readonly IRequestHendler<GetByIdConferenceRoomsQuery, ConferenceRoomEntity> _getRoomHandler;
        private readonly IRequestHendler<GetCollectionOptionalServiceQuery, IEnumerable<OptionalServiceEntity>> _getServicesHandler;

        public AddBookingHandler(IBookingRepository repository,
            IRequestHendler<GetByIdConferenceRoomsQuery, ConferenceRoomEntity> getRoomHandler,
            IRequestHendler<GetCollectionOptionalServiceQuery, IEnumerable<OptionalServiceEntity>> getServicesHandler)
        {
            _repository = repository;
            _getRoomHandler = getRoomHandler;
            _getServicesHandler = getServicesHandler;
        }
        public async Task HendlerAsync(AddBookingCommand request, CancellationToken cancellationToken = default)
        {
            var room = await _getRoomHandler.HendlerAsync(new GetByIdConferenceRoomsQuery
            {
                Id = request.ConferenceRoomId
            }, cancellationToken);

            var services = await _getServicesHandler.HendlerAsync(new GetCollectionOptionalServiceQuery
            {
                Ids = request.ServiceIds
            }, cancellationToken);

            var totalPrice = room.BaseHourPrice * (decimal)request.DurationHours.TotalHours + services.Sum(x => x.ServicePrice);

            await _repository.AddAsync(new BookingEntity
            {
                ConferenceRoomId = request.ConferenceRoomId,
                StartAt = request.StartAt,
                DurationHours = request.DurationHours,
                TotalPrice = totalPrice,
                BookingServices = request.ServiceIds.Select(x => new BookingServiceEntity
                {
                    OptionalServiceId = x
                }).ToList()
            }, cancellationToken);
        }
    }
}
