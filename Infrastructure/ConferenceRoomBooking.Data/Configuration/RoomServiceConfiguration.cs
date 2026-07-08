using ConferenceRoomBooking.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConferenceRoomBooking.Data.Configuration
{
    public class RoomServiceConfiguration : IEntityTypeConfiguration<RoomServiceEntity>
    {
        public void Configure(EntityTypeBuilder<RoomServiceEntity> builder)
        {
            builder.HasKey(k => new
            {
                k.ConferenceRoomId,
                k.OptionalServiceId
            });

            builder.HasOne(rs => rs.ConferenceRoom)
                .WithMany(r => r.RoomServices)
                .HasForeignKey(rs => rs.ConferenceRoomId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(rs => rs.OptionalService)
                .WithMany(s => s.RoomServices)
                .HasForeignKey(rs => rs.OptionalServiceId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable(nameof(RoomServiceEntity));
        }
    }
}
