namespace ITP.LocationsApi.Domain.Models
{
    public class InspectionTimeSlot
    {
        public Guid Id { get; set; }

        public Guid LocationId { get; set; }

        public Location Location { get; set; } = null!;

        public DateTime SlotStartTime { get; set; }

        public DateTime SlotEndTime { get; set; }
    }
}
