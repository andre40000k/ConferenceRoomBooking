using ConferenceRoomBooking.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConferenceRoomBooking.Data.Configuration
{
    public class BookingServiceConfiguration : IEntityTypeConfiguration<BookingServiceEntity>
    {
        public void Configure(EntityTypeBuilder<BookingServiceEntity> builder)
        {
            builder.HasKey(k => new
            {
                k.BookingId,
                k.OptionalServiceId
            });

            builder.HasOne(bs => bs.BookingEntity)
                .WithMany(b => b.BookingServices)
                .HasForeignKey(bs => bs.BookingId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(bs => bs.OptionalServiceEntity)
                .WithMany(s => s.BookingServices)
                .HasForeignKey(bs => bs.OptionalServiceId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable(nameof(BookingServiceEntity));
        }
    }
}
