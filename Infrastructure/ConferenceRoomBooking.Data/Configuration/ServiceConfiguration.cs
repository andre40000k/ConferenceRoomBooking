using ConferenceRoomBooking.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConferenceRoomBooking.Data.Configuration
{
    public class ServiceConfiguration : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd();

            builder.HasOne(c => c.ConferenceRoom)
                .WithMany(s => s.Services)
                .HasForeignKey(c => c.ConferenceRoomId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(200)
                .HasColumnType("nvarchar(200)");

            builder.Property(p => p.ServicePrice)
                .IsRequired()
                .HasColumnType("decimal(18,2)")
                .HasPrecision(18, 2);

            builder.Property(p => p.IsDeleted)
                .IsRequired()
                .HasDefaultValue(false);

            builder.ToTable("Services");
        }
    }
}
