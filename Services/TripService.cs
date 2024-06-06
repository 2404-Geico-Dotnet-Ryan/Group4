using Project2.Models;
using Project2.DTO;
using Project2.Data;

namespace Project2.Services
{
    public class TripService : ITripService
    {
        private readonly AppDbContext _context;

        public TripService(AppDbContext context)
        {
            _context = context;
        }

        public TripDTO AddTrip(TripDTO TripDTO)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TripDTO> GetAllTrips()
        {
            throw new NotImplementedException();
        }

        public TripDTO GetTripByClimate(string climate)
        {
            throw new NotImplementedException();
        }

        public TripDTO GetTripById(int tripId)
        {
            throw new NotImplementedException();
        }

        public TripDTO GetTripByLocation(string location)
        {
            throw new NotImplementedException();
        }

        public TripDTO GetTripByMaxBudge(int maxBudget)
        {
            throw new NotImplementedException();
        }

        public TripDTO GetTripByTravelType(string travelType)
        {
            throw new NotImplementedException();
        }

        public void UpdateTrip(int Id, TripDTO UpdatedTrip)
        {
            throw new NotImplementedException();
        }
    }
}