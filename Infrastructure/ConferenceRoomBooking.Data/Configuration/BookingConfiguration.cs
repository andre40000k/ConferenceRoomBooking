using ConferenceRoomBooking.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConferenceRoomBooking.Data.Configuration
{
    public class BookingConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Duration)
                .IsRequired()
                .HasColumnType("time"); 

            builder.Property(p => p.EndAt)
                .IsRequired()
                .HasColumnType("datetime2");

            builder.Property(p => p.TotalPrice)
                .IsRequired()
                .HasColumnType("decimal(18,2)")
                .HasPrecision(18, 2);

            builder.Property(p => p.Status)
                .IsRequired()
                .HasColumnType("tinyint");

            builder.ToTable(nameof(Booking));
        }
    }
}
