using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using ConferenceRoomBooking.Data.Context;

namespace ConferenceRoomBooking.Data
{
    public class ConferenceRoomBookingContextFactory : IDesignTimeDbContextFactory<ConferenceRoomBookingContext>
    {
        public ConferenceRoomBookingContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ConferenceRoomBookingContext>();
            // Используйте тот же провайдер/строку подключения, что и в приложении.
            // По умолчанию создаём локальную sqlite базу для миграций на этапе дизайна.
            builder.UseSqlite("Data Source=ConferenceRoomBookingDatabase.db");

            return new ConferenceRoomBookingContext(builder.Options);
        }
    }
}
