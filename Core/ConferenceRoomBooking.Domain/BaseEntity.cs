using ConferenceRoomBooking.Domain.Interfaces;

namespace ConferenceRoomBooking.Domain
{
    public abstract class BaseEntity : IBaseEntity
    {
        public Guid Id { get;  set; }
        //public DateTime CreatedAt { get; set; }
    }
}
