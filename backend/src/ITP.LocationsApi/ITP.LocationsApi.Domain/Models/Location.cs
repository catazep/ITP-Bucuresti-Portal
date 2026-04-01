namespace ITP.LocationsApi.Domain.Models
{
    public enum LocationStatus
    {
        Pending,
        Active,
        Rejected
    }

    public class Location
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public string City { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;

        public LocationStatus Status { get; set; }

    }
}
