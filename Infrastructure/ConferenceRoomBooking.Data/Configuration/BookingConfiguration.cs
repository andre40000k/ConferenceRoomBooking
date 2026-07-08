using ConferenceRoomBooking.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConferenceRoomBooking.Data.Configuration
{
    public class BookingConfiguration : IEntityTypeConfiguration<BookingEntity>
    {
        public void Configure(EntityTypeBuilder<BookingEntity> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd();

            builder.Property(p => p.StartAt)
            .IsRequired();

            builder.Property(p => p.DurationHours)
                .IsRequired()
                .HasColumnType("time");

            builder.Property(p => p.TotalPrice)
                .IsRequired()
                .HasColumnType("decimal(18,2)")
                .HasPrecision(18, 2);

            builder.HasOne(b => b.ConferenceRoomEntity)
                .WithMany(r => r.BookingEntitys)
                .HasForeignKey(b => b.ConferenceRoomId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable(nameof(BookingEntity));
        }
    }
}
