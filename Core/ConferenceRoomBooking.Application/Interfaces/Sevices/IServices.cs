using ConferenceRoomBooking.Domain;

namespace ConferenceRoomBooking.Application.Interfaces.Sevices
{
    public interface IResponsHendler<IRespons>
    {
        Task<IRespons> HendlerAsync(CancellationToken cancellationToken = default);
    }
    public interface IRequestHendler<in IRequest>
    {
        Task HendlerAsync(IRequest request, CancellationToken cancellationToken = default);
    }

    public interface IRequestHendler<in IRequest, IRespons>
    {
        Task<IRespons> HendlerAsync(IRequest request, CancellationToken cancellationToken = default);
    }

    public interface IRequestHendler<in IRequestFirst, in IRequestSecond, IRespons>
    {
        Task<IRespons> HendlerAsync(IRequestFirst requestFirst, IRequestSecond requestSecond, CancellationToken cancellationToken = default);
    }

    public interface IGetRepository
    {
    }

    public interface ISetRepository
    {
        Task AddEntityAsync(BaseEntity baseEntity, CancellationToken cancellationToken = default);

        Task AddRangeEntitiesAsync<T>(List<T> baseEntities, CancellationToken cancellationToken = default) where T : BaseEntity;

        /*Task<Shop> GetByIdAsync(Guid shopId, CancellationToken cancellationToken = default);*/
    }
}
