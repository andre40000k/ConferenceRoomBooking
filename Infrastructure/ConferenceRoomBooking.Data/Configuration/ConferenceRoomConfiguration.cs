using ConferenceRoomBooking.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConferenceRoomBooking.Data.Configuration
{
    public class ConferenceRoomConfiguration : IEntityTypeConfiguration<ConferenceRoomEntity>
    {
        public void Configure(EntityTypeBuilder<ConferenceRoomEntity> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(200)
                .HasColumnType("nvarchar(200)");

            builder.Property(p => p.Capacity)
                .IsRequired();

            builder.Property(p => p.BaseHourPrice)
                .IsRequired()
                .HasColumnType("decimal(18,2)")
                .HasPrecision(18, 2);

            builder.ToTable(nameof(ConferenceRoomEntity));
        }
    }
}
