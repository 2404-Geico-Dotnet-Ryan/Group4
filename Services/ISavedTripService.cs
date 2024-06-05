
using Project2.Models;
using Project2.DTO;

namespace Project2.Services
{
    public interface ISavedTripService
    {
        IEnumerable<SavedTripDTO> GetAllSavedTrips(); // Method to get a list of saved trips 
        SavedTripDTO GetSavedTripById(int tripId); // Get saved trip by id
        SavedTripDTO AddSavedTrip(SavedTripDTO savedTripDTO); // Add a saved trip
        void UpdateSavedTrip(int tripId, SavedTripDTO updatedSavedTrip); // Method to make changes to a saved trip
        void DeleteSavedTrip(int tripId); // Delete a saved trip
    }
}