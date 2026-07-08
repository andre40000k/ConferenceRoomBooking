using ConferenceRoomBooking.Domain.Entities;

namespace ConferenceRoomBooking.Application.Interfaces.Repositories
{
    public interface IOptionalServiceRepository
    {
        Task AddAsync(
        OptionalServiceEntity optionalServiceEntity,
        CancellationToken cancellationToken);
    }
}
