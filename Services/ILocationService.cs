using Project2.Models;
using Project2.DTO;

namespace Project2.Services

{
    public interface ILocationService 
    {
        IEnumerable<LocationDTO> GetAllLocations();
        LocationDTO GetLocationById(int locationId);
        LocationDTO AddLocation(LocationDTO locationDTO);
        LocationDTO UpdateLocation(int locationId, LocationDTO updatedLocation);
        void DeleteLocation(int locationId);
    }
}