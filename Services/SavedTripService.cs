using Project2.Models;
using Project2.DTO;
using Project2.Data;
using Project2.Controllers;

namespace Project2.Services

{
    public class SavedTripService : ISavedTripService
    {
        private readonly AppDbContext _context;

        public SavedTripService(AppDbContext context)
        {
            _context = context;
        }

        public SavedTrip AddSavedTrip(SavedTripDTO savedTripDTO)
        {
            SavedTrip savedTrip = new SavedTrip
            {
                UId = savedTripDTO.UId,
                Season = savedTripDTO.Season,
                Location = savedTripDTO.Location,
                MaxBudget = savedTripDTO.MaxBudget,
                NumOfTravelers = savedTripDTO.NumOfTravelers,
                TravelType = savedTripDTO.TravelType,
                ClimatePref = savedTripDTO.ClimatePref,
                PassportStatus = savedTripDTO.PassportStatus,
                //ActivityName = savedTripDTO.IncludedActivities
            };
            _context.SavedTrips.Add(savedTrip);
            _context.SaveChanges();
            return savedTrip;
        }

        public void DeleteSavedTrip(int tripId)
        {
            var savedTrip = _context.SavedTrips.FirstOrDefault(s => s.TripId == tripId);
            if (savedTrip != null)
            {
                _context.SavedTrips.Remove(savedTrip);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Trip not found");
            }
        }

        public IEnumerable<SavedTripDTO> GetAllSavedTrips()
        {
            var savedTrips = _context.SavedTrips.Select(s => new SavedTripDTO
            {
                TripId = s.TripId,
                UId = s.UId,
                Season = s.Season,
                Location = s.Location,
                MaxBudget = s.MaxBudget,
                NumOfTravelers = s.NumOfTravelers,
                TravelType = s.TravelType,
                ClimatePref = s.ClimatePref,
                PassportStatus = s.PassportStatus,
                //IncludedActivities = s.IncludedActivities
            }).ToList();
            return savedTrips;
        }

        public SavedTripDTO GetSavedTripById(int tripId)
        {
            var savedTrip = _context.SavedTrips.Find(tripId);
            if (savedTrip != null)
            {
                var savedTripDTO = new SavedTripDTO
                {
                    TripId = savedTrip.TripId,
                    UId = savedTrip.UId,
                    Season = savedTrip.Season,
                    Location = savedTrip.Location,
                    MaxBudget = savedTrip.MaxBudget,
                    NumOfTravelers = savedTrip.NumOfTravelers,
                    TravelType = savedTrip.TravelType,
                    ClimatePref = savedTrip.ClimatePref,
                    PassportStatus = savedTrip.PassportStatus,
                    //IncludedActivities = savedTrip.IncludedActivities
                };
                return savedTripDTO;
            }
            else
            {
                throw new Exception("Trip not found");

            }

        }

        public SavedTripDTO UpdateSavedTrip(int tripId, SavedTripDTO updatedSavedTripDTO)
        {
            var savedTrip = _context.SavedTrips.Find(tripId);
            if (savedTrip == null)
            {
                return null;
            }
            savedTrip.UId = updatedSavedTripDTO.UId;
            savedTrip.Season = updatedSavedTripDTO.Season;
            savedTrip.Location = updatedSavedTripDTO.Location;
            savedTrip.MaxBudget = updatedSavedTripDTO.MaxBudget;
            savedTrip.NumOfTravelers = updatedSavedTripDTO.NumOfTravelers;
            savedTrip.TravelType = updatedSavedTripDTO.TravelType;
            savedTrip.ClimatePref = updatedSavedTripDTO.ClimatePref;
            savedTrip.PassportStatus = updatedSavedTripDTO.PassportStatus;
            //savedTrip.IncludedActivities = updatedSavedTripDTO.IncludedActivities;
            _context.Entry(savedTrip).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return updatedSavedTripDTO;
        }

        SavedTripDTO ISavedTripService.AddSavedTrip(SavedTripDTO savedTripDTO)
        {
            throw new NotImplementedException();
        }

        void ISavedTripService.UpdateSavedTrip(int tripId, SavedTripDTO updatedSavedTrip)
        {
            throw new NotImplementedException();
        }
    }
}