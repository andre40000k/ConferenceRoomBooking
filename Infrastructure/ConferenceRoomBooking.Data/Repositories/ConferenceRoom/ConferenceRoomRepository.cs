using ConferenceRoomBooking.Application.DTOs.Responses.ConferenceRoom;
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

        public async Task<IEnumerable<AvailableConferenceRoomRespons>> GetAvailableRoomsAsync(DateTime startDateTime, TimeSpan durationHours, int capacity, CancellationToken cancellationToken = default)
        {
            var endDateTime = startDateTime.Add(durationHours);

            var rooms = await _db.ConferenceRooms
                .AsNoTracking()
                .Where(r => r.Capacity >= capacity)
                .Where(r => !r.BookingEntitys.Any(b =>
                    startDateTime < b.StartAt.Add(b.DurationHours) &&
                    endDateTime > b.StartAt))
                .Select(r => new AvailableConferenceRoomRespons
                {
                    Id = r.Id,
                    Name = r.Name,
                    Capacity = r.Capacity,
                    BaseHourPrice = r.BaseHourPrice,
                })
                .ToListAsync(cancellationToken);

            return rooms;
        }

        public async Task<ConferenceRoomEntity> GetByIdRoomsAsync(Guid Id, CancellationToken cancellationToken = default)
        {
            var room = await _db.ConferenceRooms
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == Id, cancellationToken);

            if (room is null)
                throw new InvalidOperationException($"Conference room with Id '{Id}' not found.");
            return room;
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
