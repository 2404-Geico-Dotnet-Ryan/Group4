using Project2.Models;
using Project2.DTO;

namespace Project2.Services
{
    public interface IClimateService
    {
        IEnumerable<ClimateDTO> GetAllClimates();
        ClimateDTO GetClimateById(int climateId);
        ClimateDTO AddClimate(ClimateDTO climateDTO);
        ClimateDTO UpdateClimate(int climateId, ClimateDTO updatedClimate);
        void DeleteClimate(int climateId);
    }
}