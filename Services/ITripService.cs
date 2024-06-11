using Project2.Models;
using Project2.DTO;

namespace Project2.Services
{
    public interface ITripService
    {
        IEnumerable<TripDTO> GetAllTrips();
        TripDTO GetTripById(int tripId);
       // TripDTO GetTripByLocation(string location);
       // TripDTO GetTripByMaxBudget(int maxBudget);
        //TripDTO GetTripByTravelType(string travelType);
        //TripDTO GetTripByClimate(string climate);
        Trip AddTrip(TripDTO TripDTO);
        TripDTO UpdateTrip(int tripId, TripDTO UpdatedTrip);
        void DeleteTrip(int tripId);
    }
}
