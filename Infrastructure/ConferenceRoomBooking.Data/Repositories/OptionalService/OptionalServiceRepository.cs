using ConferenceRoomBooking.Application.Interfaces.Repositories;
using ConferenceRoomBooking.Application.Queries.OptionalService;
using ConferenceRoomBooking.Data.Context;
using ConferenceRoomBooking.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ConferenceRoomBooking.Data.Repositories.OptionalService
{
    public class OptionalServiceRepository : IOptionalServiceRepository
    {
        private readonly ConferenceRoomBookingContext _db;

        public OptionalServiceRepository(ConferenceRoomBookingContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db)); ;
        }
        public async Task AddAsync(OptionalServiceEntity optionalServiceEntity, CancellationToken cancellationToken)
        {
            _db.OptionalServices.Add(optionalServiceEntity);
            await _db.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<OptionalServiceEntity>> GetCollectionSirviceAsync(GetCollectionOptionalServiceQuery query, CancellationToken cancellationToken = default)
        {
            return await _db.OptionalServices
                .Where(x => query.Ids.Contains(x.Id))
                .ToListAsync(cancellationToken);
        }
    }
}
