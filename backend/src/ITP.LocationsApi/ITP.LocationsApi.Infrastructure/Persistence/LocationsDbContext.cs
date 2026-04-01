using ITP.LocationsApi.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ITP.LocationsApi.Infrastructure.Persistence
{
    public class LocationsDbContext : DbContext
    {
        public LocationsDbContext(DbContextOptions<LocationsDbContext> options) : base(options)
        {
        }

        public DbSet<Location> Locations => Set<Location>();
        public DbSet<InspectionTimeSlot> InspectionTimeSlots => Set<InspectionTimeSlot>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(LocationsDbContext).Assembly);
        }
    }
}
