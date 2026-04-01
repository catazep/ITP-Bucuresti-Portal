using ITP.LocationsApi.Application.Interfaces;
using ITP.LocationsApi.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ITP.LocationsApi.Infrastructure.Persistence.Repositories
{
    public class LocationRepository : ILocationRepository
    {
        private readonly LocationsDbContext _context;

        public LocationRepository(LocationsDbContext context)
        {
            _context = context;
        }

        public async Task<List<Location>> GetAllAsync(List<LocationStatus> excludedStatuses, CancellationToken ct = default)
        {
            return await _context.Locations.Where(l => !excludedStatuses.Contains(l.Status)).ToListAsync(ct);
        }

        public async Task<Location?> GetByIdAsync(Guid id, CancellationToken ct = default)
        {
            return await _context.Locations.FindAsync([id], ct);
        }

        public async Task<int> AddAsync(Location location, CancellationToken ct = default)
        {
            _context.Locations.Add(location);
            return await _context.SaveChangesAsync(ct);
        }

        public async Task<int> UpdateAsync(Location location, CancellationToken ct = default)
        {
            _context.Locations.Update(location);
            return await _context.SaveChangesAsync(ct);
        }

        public async Task<int> DeleteByIdAsync(Guid id, CancellationToken ct = default)
        {
            var existingLocation = await _context.Locations.FindAsync([id], ct);

            if (existingLocation is null)
            {
                return 0;
            }

            _context.Locations.Remove(existingLocation);
            return await _context.SaveChangesAsync(ct);
        }
    }
}
