using Project2.Models;
using Project2.DTO;
using Project2.Data;
using Project2.Controllers;

namespace Project2.Services

{
    public class LocationService : ILocationService
    {
        private readonly AppDbContext _context;
        public LocationService(AppDbContext context)
        {
            _context = context;
        }

        public LocationDTO AddLocation(LocationDTO locationDTO)
        {
            Location location = new Location
            {
                LocationId = locationDTO.LocationId,
                LocationName = locationDTO.LocationName
            };
            _context.Locations.Add(location);
            _context.SaveChanges();
            return locationDTO;
        }

        public void DeleteLocation(int locationId)
        {
            var location = _context.Locations.FirstOrDefault(l => l.LocationId == locationId);
            if (location != null)
            {
                _context.Locations.Remove(location);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Location not found.");
            }
        }

        public IEnumerable<LocationDTO> GetAllLocations()
        {
            var locations = _context.Locations.Select(l => new LocationDTO
            {
                LocationId = l.LocationId,
                LocationName = l.LocationName
            }).ToList();
            return locations;
        }

        public LocationDTO GetLocationById(int locationId)
        {
            var location = _context.Locations.Find(locationId);
            if (location != null)
            {
                var locationDTO = new LocationDTO
                {
                    LocationId = location.LocationId,
                    LocationName = location.LocationName
                };
                return locationDTO;
            }
            else
            {
                throw new Exception("Location not found.");
            }
        }

        public LocationDTO UpdateLocation(int locationId, LocationDTO updatedLocation)
        {
            var location = _context.Locations.Find(locationId);
            if (location == null)
            {
                return null;
            }
            location.LocationId = updatedLocation.LocationId;
            location.LocationName = updatedLocation.LocationName;

            _context.Locations.Update(location);

            return updatedLocation;
        }
    }

}