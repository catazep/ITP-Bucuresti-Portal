using ITP.LocationsApi.Domain.Models;
using MediatR;

namespace ITP.LocationsApi.Application.Queries
{
    public record GetLocationsQuery(IList<LocationStatus>ExcludedStatuses) : IRequest<List<Location>>;
}
