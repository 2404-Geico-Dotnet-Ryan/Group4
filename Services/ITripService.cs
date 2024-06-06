using Project2.Models;
using Project2.DTO;

namespace Project2.Services
{
    public interface ITripService
    {
        IEnumerable<TripDTO> GetAllTrips();
        TripDTO GetTripById(int tripId);
        TripDTO GetTripByLocation(string location);
        TripDTO GetTripByMaxBudge(int maxBudget);
        TripDTO GetTripByTravelType(string travelType);
        TripDTO GetTripByClimate(string climate);
        TripDTO AddTrip(TripDTO TripDTO);
        void UpdateTrip(int Id, TripDTO UpdatedTrip);
    }
}
