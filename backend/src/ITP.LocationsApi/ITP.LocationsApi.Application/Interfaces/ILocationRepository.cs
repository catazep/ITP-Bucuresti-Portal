using ITP.LocationsApi.Domain.Models;

namespace ITP.LocationsApi.Application.Interfaces
{
    public interface ILocationRepository
    {
        Task<List<Location>> GetAllAsync(List<LocationStatus> excludedStatuses, CancellationToken ct = default);
        Task<Location?> GetByIdAsync(Guid id, CancellationToken ct = default);
        Task<int> AddAsync(Location location, CancellationToken ct = default);
        Task<int> UpdateAsync(Location location, CancellationToken ct = default);
        Task<int> DeleteByIdAsync(Guid id, CancellationToken ct = default);
    }
}
