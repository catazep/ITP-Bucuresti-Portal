using ITP.LocationsApi.Application.Interfaces;
using ITP.LocationsApi.Domain.Models;
using MediatR;

namespace ITP.LocationsApi.Application.Queries
{
    public class GetLocationsQueryHandler : IRequestHandler<GetLocationsQuery, List<Location>>
    {
        private readonly ILocationRepository _locationRepository;

        public GetLocationsQueryHandler(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public Task<List<Location>> Handle(GetLocationsQuery request, CancellationToken cancellationToken)
        {
            return _locationRepository.GetAllAsync(request.ExcludedStatuses, cancellationToken);
        }
    }
}
