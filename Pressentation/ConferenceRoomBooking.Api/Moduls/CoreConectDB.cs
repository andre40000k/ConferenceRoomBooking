using ConferenceRoomBooking.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace ConferenceRoomBooking.Api.Moduls
{
    public static class CoreConectDB
    {
        public static IServiceCollection AddConectDb(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddDbContext<ConferenceRoomBookingContext>(options =>
            {
                var conectionString = configuration.GetConnectionString("ConferenceRoomBookingDatabase");

                options.UseSqlite(conectionString);
            });

            return services;
        }
    }
}
