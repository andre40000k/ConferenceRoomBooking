using ConferenceRoomBooking.Domain.Entities;

namespace ConferenceRoomBooking.Application.Interfaces.Repositories
{
    public interface IConferenceRoomRepository
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
    }
}
