using ConferenceRoomBooking.Application.DTOs.Responses.Booking;
using ConferenceRoomBooking.Application.Interfaces.Repositories;
using ConferenceRoomBooking.Application.Interfaces.Sevices;
using ConferenceRoomBooking.Application.Queries.Calculation;
using ConferenceRoomBooking.Application.Queries.ConferenceRoom;
using ConferenceRoomBooking.Application.Queries.OptionalService;
using ConferenceRoomBooking.Domain.Entities;

namespace ConferenceRoomBooking.Application.Commands.Booking
{
    public class AddBookingHandler : IRequestHandler<AddBookingCommand, AddBookingResponse>
    {
        private readonly IBookingRepository _repository;
        private readonly IRequestHandler<GetByIdConferenceRoomsQuery, ConferenceRoomEntity> _getRoomHandler;
        private readonly IRequestHandler<GetCollectionOptionalServiceQuery, IEnumerable<OptionalServiceEntity>> _getServicesHandler;
        private readonly IRequestHandler<CalculateRentPriceQuery, decimal> _requestCalculateRentHendler;

        public AddBookingHandler(IBookingRepository repository,
            IRequestHandler<GetByIdConferenceRoomsQuery, ConferenceRoomEntity> getRoomHandler,
            IRequestHandler<GetCollectionOptionalServiceQuery, IEnumerable<OptionalServiceEntity>> getServicesHandler,
            IRequestHandler<CalculateRentPriceQuery, decimal> requestCalculateRentHendler)
        {
            _repository = repository;
            _getRoomHandler = getRoomHandler;
            _getServicesHandler = getServicesHandler;
            _requestCalculateRentHendler = requestCalculateRentHendler;
        }
        public async Task<AddBookingResponse> HandlerAsync(AddBookingCommand request, CancellationToken cancellationToken = default)
        {
            var room = await _getRoomHandler.HandlerAsync(new GetByIdConferenceRoomsQuery
            {
                Id = request.ConferenceRoomId
            }, cancellationToken);

            var endAt = request.StartAt.Add(request.DurationHours);
            var isAvailable = !room.BookingEntitys.Any(b => 
                request.StartAt < b.StartAt.Add(b.DurationHours) &&
                endAt > b.StartAt);

            if (!isAvailable)
                return new AddBookingResponse
                {
                    TotalPrice = 0,
                    Status = "Fail"
                };

            var services = await _getServicesHandler.HandlerAsync(new GetCollectionOptionalServiceQuery
            {
                Ids = request.ServiceIds
            }, cancellationToken);

            var rentPrice = await _requestCalculateRentHendler.HandlerAsync(new CalculateRentPriceQuery
            {
                StartAt = request.StartAt,
                BaseHourPrice = room.BaseHourPrice,
                DurationHours = request.DurationHours
            }, cancellationToken);

            var totalPrice = rentPrice + services.Sum(x => x.ServicePrice);

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

            return new AddBookingResponse
            {
                TotalPrice = totalPrice,
                Status = "Success"
            };
        }
    }
}
