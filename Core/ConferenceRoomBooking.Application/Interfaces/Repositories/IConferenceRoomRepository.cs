using ConferenceRoomBooking.Application.DTOs.Responses.ConferenceRoom;
using ConferenceRoomBooking.Domain.Entities;

namespace ConferenceRoomBooking.Application.Interfaces.Repositories
{
    public interface IConferenceRoomRepository : IBaseRepository
    {
        Task AddAsync(
        ConferenceRoomEntity conferenceRoomEntity,
        CancellationToken cancellationToken);

        Task UpdateAsync(
        Guid id,
        string name,
        int capacity,
        decimal basePrice,
        CancellationToken cancellationToken);

        Task DeletedAsync(Guid id,
            CancellationToken cancellationToken);

        Task<ConferenceRoomEntity> GetByIdRoomsAsync(
        Guid Id,
        CancellationToken cancellationToken = default);

        Task<IEnumerable<AvailableConferenceRoomRespons>> GetAvailableRoomsAsync(
        DateTime startDateTime,
        TimeSpan durationHours,
        int capacity,
        CancellationToken cancellationToken = default);
    }
}
