using ConferenceRoomBooking.Application.Interfaces.Repositories;
using ConferenceRoomBooking.Data.Context;
using ConferenceRoomBooking.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ConferenceRoomBooking.Data.Repositories.ConferenceRoom
{
    public class ConferenceRoomRepository : IConferenceRoomRepository
    {
        private readonly ConferenceRoomBookingContext _db;

        public ConferenceRoomRepository(ConferenceRoomBookingContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db)); ;
        }

        public async Task AddAsync(ConferenceRoomEntity conferenceRoomEntity, CancellationToken cancellationToken)
        {
            _db.ConferenceRooms.Add(conferenceRoomEntity);
            await _db.SaveChangesAsync(cancellationToken);
        }

        public async Task DeletedAsync(Guid id, CancellationToken cancellationToken)
        {
            await _db.ConferenceRooms.Where(x => x.Id == id).ExecuteDeleteAsync(cancellationToken);
        }

        public async Task UpdateAsync(Guid id, string name, int capacity, decimal basePrice, CancellationToken cancellationToken)
        {
            await _db.ConferenceRooms
            .Where(x => x.Id == id)
            .ExecuteUpdateAsync(s => s
                .SetProperty(x => x.Name, name)
                .SetProperty(x => x.Capacity, capacity)
                .SetProperty(x => x.BaseHourPrice, basePrice),
                cancellationToken);
        }


    }
}
