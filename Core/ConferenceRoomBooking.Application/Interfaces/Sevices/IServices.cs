using ConferenceRoomBooking.Domain;

namespace ConferenceRoomBooking.Application.Interfaces.Sevices
{
    public interface IResponsHandler<IRespons>
    {
        Task<IRespons> HandlerAsync(CancellationToken cancellationToken = default);
    }
    public interface IRequestHandler<in IRequest>
    {
        Task HandlerAsync(IRequest request, CancellationToken cancellationToken = default);
    }

    public interface IRequestHandler<in IRequest, IRespons>
    {
        Task<IRespons> HandlerAsync(IRequest request, CancellationToken cancellationToken = default);
    }

    public interface IRequestHandler<in IRequestFirst, in IRequestSecond, IRespons>
    {
        Task<IRespons> HandlerAsync(IRequestFirst requestFirst, IRequestSecond requestSecond, CancellationToken cancellationToken = default);
    }
}
