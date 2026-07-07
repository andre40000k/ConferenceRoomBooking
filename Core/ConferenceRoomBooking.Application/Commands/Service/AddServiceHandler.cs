using ConferenceRoomBooking.Application.Interfaces.Sevices;
using ConferenceRoomBooking.Domain.Entities;
using ConferenceRoomBooking.Domain.Interfaces.DbContext;

namespace ConferenceRoomBooking.Application.Commands.Service
{
    public class AddServiceHandler : IRequestHendler<UpsertServiceCommand>
    {
        private readonly IConferenceRoomBookingContext _db;
        public AddServiceHandler(IConferenceRoomBookingContext db) 
        {
            _db = db;
        }
        public async Task HendlerAsync(UpsertServiceCommand request, CancellationToken cancellationToken = default)
        {
            var service = new OptionalService
            {
                Name = request.Name,
                ServicePrice = request.Price
            };
            
            _db.OptionalServices.Add(service);
            var saved = await _db.SaveChangesAsync(cancellationToken);
        }
    }
}
