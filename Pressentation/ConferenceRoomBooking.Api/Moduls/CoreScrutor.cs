using ConferenceRoomBooking.Application.Interfaces.Sevices;
using ConferenceRoomBooking.Data.Context;
using ConferenceRoomBooking.Domain.Interfaces.DbContext;

namespace ConferenceRoomBooking.Api.Moduls
{
    public static class CoreScrutor
    {
        public static IServiceCollection AddScrutor(this IServiceCollection services)
        {
            services.Scan(scan => scan
            .FromApplicationDependencies()
            .AddClasses(classes => classes.AssignableTo(typeof(IResponsHendler<>)))
                .AsImplementedInterfaces()
                .WithScopedLifetime()
            .AddClasses(classes => classes.AssignableTo(typeof(IRequestHendler<>)))
                .AsImplementedInterfaces()
                .WithScopedLifetime()
            .AddClasses(classes => classes.AssignableTo(typeof(IRequestHendler<,>)))
                .AsImplementedInterfaces()
                .WithScopedLifetime()
            .AddClasses(classes => classes.AssignableTo(typeof(IRequestHendler<,,>)))
                .AsImplementedInterfaces()
                .WithScopedLifetime()
            .AddClasses(classes => classes.AssignableTo(typeof(ISetRepository)))
                .AsImplementedInterfaces()
                .WithScopedLifetime()
            .AddClasses(classes => classes.AssignableTo(typeof(IGetRepository)))
                .AsImplementedInterfaces()
                .WithScopedLifetime());

            return services;
        }
    }
}
