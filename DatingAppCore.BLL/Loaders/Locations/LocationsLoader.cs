using CommonCore.Interfaces.Repository;
using CommonCore2.Mathematics;
using CommonCore.Models.Repo;
using DatingAppCore.BLL.Interfaces.Loaders.Locations;
using DatingAppCore.Dto.Requests;
using DatingAppCore.Entities.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingAppCore.BLL.Loaders.Locations
{
    public class LocationsLoader : ILocationsLoader
    {
        private readonly ICrudRepository<UserLocation> _repository;

        public async Task<IEnumerable<UserLocation>> UsersWithinLocation(FindMatchesRequest request)
        {
            HaversineCalculator haversineCalculator = new HaversineCalculator();

            var latRadius = request.SurfaceRadius / 69;
            var lonRadius = haversineCalculator.Longitude2(request.SurfaceRadius, request.Latitude, request.Latitude, request.Longitude) - request.Longitude;
            var latNorth = request.Latitude + latRadius;
            var latSouth = request.Latitude - latRadius;
            var lonWest = request.Longitude - lonRadius;
            var lonEast = request.Longitude + lonRadius;

            List<UserLocation> result = new List<UserLocation>();
            IEnumerable<UserLocation> inSquares = new List<UserLocation>();

            while (
                result.Count() > 0
                && await LocationsInSquare(request,
                    inSquares,
                    latNorth,
                    latSouth,
                    lonWest,
                    lonEast
                    ))
            {
                foreach (var inSquare in inSquares)
                {
                    var distance = haversineCalculator.DistanceMiles(request.Latitude, inSquare.Lat, request.Longitude, inSquare.Lon);
                    if (distance < request.SurfaceRadius)
                        result.Add(inSquare);
                }
                request.Skip += request.Take;
            }
            return result;
        }

        private async Task<bool> LocationsInSquare(
            FindMatchesRequest request,
            IEnumerable<UserLocation> inSquare,
            double latNorth,
            double latSouth,
            double lonWest,
            double lonEast
            )
        {
            inSquare = await _repository.Read(new SearchRequest<UserLocation>()
            {
                Skip = request.Skip,
                Limit = request.Take,
                Filter = x =>
                    x.Lat < latNorth
                    && x.Lat > latSouth
                    && x.Lon > lonWest
                    && x.Lon < lonEast
                    && !request.AlreadySwiped.Contains(x.ID)
            });

            return inSquare.Any();
        }
    }
}
