using ConferenceRoomBooking.Data.Context;
using ConferenceRoomBooking.Domain.Interfaces.DbContext;
using Microsoft.EntityFrameworkCore;

namespace ConferenceRoomBooking.Api.Moduls
{
    public static class CoreConectDB
    {
        public static IServiceCollection AddConectDb(this IServiceCollection services, ConfigurationManager configuration)
        {
            // Регистрируем контекст с использованием ключа DefaultConnection из appsettings
            services.AddDbContext<ConferenceRoomBookingContext>(options =>
            {
                var connectionString = configuration.GetConnectionString("DefaultConnection");

                // Указываем MigrationsAssembly чтобы миграции находились в сборке с контекстом
                options.UseSqlite(connectionString, b => b.MigrationsAssembly(typeof(ConferenceRoomBookingContext).Assembly.FullName));
            });

            services.AddScoped<IConferenceRoomBookingContext>(provider =>provider.GetRequiredService<ConferenceRoomBookingContext>());

            return services;
        }
    }
}
