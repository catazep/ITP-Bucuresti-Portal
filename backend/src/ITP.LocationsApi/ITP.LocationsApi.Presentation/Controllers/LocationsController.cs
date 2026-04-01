using ITP.LocationsApi.Application.Interfaces;
using ITP.LocationsApi.Domain.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ITP.LocationsApi.Presentation.Controllers
{
    [ApiController]
    [Route("api/locations")]
    public class LocationsController : ControllerBase
    {
        private readonly ILocationRepository _locationRepository;

        public LocationsController(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Location>>> GetAllAsync([FromQuery] string excluded, CancellationToken ct)
        {
            // TODO: perhaps make an enum parser interceptor as an excercise
            var excludedStatuses = excluded?
                .Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                .Select(s => Enum.TryParse<LocationStatus>(s, true, out var status) ? status : (LocationStatus?)null)
                .OfType<LocationStatus>() // Filters out the nulls (failed parses)
                .ToList()

        ?? new List<LocationStatus>();
            var locations = await _locationRepository.GetAllAsync(excludedStatuses, ct);
            return Ok(locations);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<Location?>> GetByIdAsync(Guid id, CancellationToken ct)
        {
            var location = await _locationRepository.GetByIdAsync(id, ct);

            if (location is null)
            {
                return NotFound();
            }

            return Ok(location);
        }

        [HttpPost]
        public async Task<ActionResult<Location>> GetByIdAsync([FromBody] CreateLocationRequest request, CancellationToken ct)
        {
            var location = new Location
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Address = request.Address,
                City = request.City,
                Phone = request.Phone,
                Status = LocationStatus.Pending
            };

            await _locationRepository.AddAsync(location, ct);

            return CreatedAtAction(nameof(GetByIdAsync), new { id = location.Id }, location);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<Guid>> DeleteByIdAsync(Guid id, CancellationToken ct)
        {
            var removedEntities = await _locationRepository.DeleteByIdAsync(id, ct);
            if (removedEntities == 0)
            {
                return NotFound(id);
            }

            return Ok(id);
        }


    }

    // Simple request DTO — lives here for now, will move to Application layer with MediatR later
    public record CreateLocationRequest(string Name, string Address, string City, string Phone);
}
