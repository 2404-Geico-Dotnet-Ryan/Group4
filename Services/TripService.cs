using Project2.Models;
using Project2.DTO;
using Project2.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;
using System.Collections;

namespace Project2.Services
{
    public class TripService : ITripService
    {
        private readonly AppDbContext _context;

        public TripService(AppDbContext context)
        {
            _context = context;
        }

        public Trip AddTrip(TripDTO tripDTO)
        {
            var activities = _context.Activities.FirstOrDefault(a => a.ActivityName == tripDTO.ActivityName);
            var location = _context.Locations.FirstOrDefault(l => l.LocationName == tripDTO.LocationName);
            var climate = _context.Climates.FirstOrDefault(c => c.ClimateType == tripDTO.ClimateType);
            var travelType = _context.TravelTypes.FirstOrDefault(t => t.TravelTypeName == tripDTO.TravelTypeName);


            var trip = new Trip
            {
                TripName = tripDTO.TripName,
                MaxBudget = tripDTO.MaxBudget,
                NeedsPassport = tripDTO.NeedsPassport,
                Activity = activities,
                Location = location,
                Climate = climate,
                TravelType = travelType

            };
            _context.Trips.Add(trip);
            _context.SaveChanges();

            return trip;
        }

        public void DeleteTrip(int tripId)
        {
            var trip = _context.Trips.Find(tripId);
            if (trip != null)
            {
            _context.Trips.Remove(trip);
            _context.SaveChanges();
            }
            else
            {
                throw new Exception ("Trip not found");
            }
        }

         public IEnumerable<TripDTO> GetAllTrips()
        {
            var trips = _context.Trips
                .Include(t => t.Activity)
                .Include(t => t.TravelType)
                .Include(t => t.Climate)
                .Include(t => t.Location)
                .Select(t => new TripDTO
                {
                    TripId = t.TripId,
                    TripName = t.TripName,
                    MaxBudget = t.MaxBudget,
                    NeedsPassport = t.NeedsPassport,
                    ActivityName = t.Activity.ActivityName, 
                    LocationName = t.Location.LocationName,
                    ClimateType = t.Climate.ClimateType,
                    TravelTypeName = t.TravelType.TravelTypeName


                }).ToList();
            return trips;
        }
        // Find a trip by tripId
          public TripDTO GetTripById(int tripId)
        {
             var trip = _context.Trips
                .Include( t=> t.Activity)
                .Include(t => t.TravelType)
                .Include(t => t.Climate)
                .Include(t => t.Location)
                .FirstOrDefault(t => t.TripId == tripId);
            if (trip != null)
            {               
                
                var tripDTO = new TripDTO{
                    TripId = trip.TripId,
                    TripName = trip.TripName,                
                    MaxBudget = trip.MaxBudget,
                    NeedsPassport = trip.NeedsPassport,
                     ActivityName = trip.Activity.ActivityName, 
                     LocationName = trip.Location.LocationName,
                    ClimateType = trip.Climate.ClimateType,
                    TravelTypeName = trip.TravelType.TravelTypeName,

                };
                return tripDTO;
            }
            else
            {
                throw new Exception ("Trip not found");
            }
        }

        // Find a trip by LocationName
        public IEnumerable<TripDTO> GetTripByLocation(string locationName)
        {
            var location = _context.Locations;
            var trips = _context.Trips
                .Include( t=> t.Activity)
                .Include(t => t.TravelType)
                .Include(t => t.Climate)
                .Include(t => t.Location)
                .Where(t => t.Location.LocationName == locationName)
                .Select(t => new TripDTO
                {
                    TripId = t.TripId,
                    TripName = t.TripName,
                    MaxBudget = t.MaxBudget,
                    NeedsPassport = t.NeedsPassport,
                    ActivityName = t.Activity.ActivityName, 
                    LocationName = t.Location.LocationName,
                    ClimateType = t.Climate.ClimateType,
                    TravelTypeName = t.TravelType.TravelTypeName


                }).ToList();
            return trips;
        }

        /* public TripDTO GetTripByClimate(string climate)
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
         }*/

        public TripDTO UpdateTrip(int tripId, TripDTO UpdatedTrip)
        {
             var trip = _context.Trips.Include(t => t.Location)
                .Include(t => t.Climate) 
                .Include(t => t.TravelType)
                .Include(t => t.Activity)
                .FirstOrDefault(t => t.TripId == tripId);
            var location = _context.Locations.FirstOrDefault(l => l.LocationName == UpdatedTrip.LocationName);   
            var climate = _context.Climates.FirstOrDefault(c => c.ClimateType == UpdatedTrip.ClimateType);
            var travelType = _context.TravelTypes.FirstOrDefault(t => t.TravelTypeName == UpdatedTrip.TravelTypeName);
            var activity = _context.Activities.FirstOrDefault(a => a.ActivityName == UpdatedTrip.ActivityName);
            
            if (trip == null)
            {
                return null;
            }

            trip.TripName = UpdatedTrip.TripName;
            trip.MaxBudget = UpdatedTrip.MaxBudget;
            trip.NeedsPassport = UpdatedTrip.NeedsPassport;
            trip.Activity = activity;
            trip.Location = location;
            trip.Climate = climate;
            trip.TravelType = travelType;


            _context.Trips.Update(trip);
            _context.SaveChanges();
            return UpdatedTrip;
        }
        


    }
}