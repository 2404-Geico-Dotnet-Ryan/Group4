using Project2.Models;
using Project2.DTO;
using Project2.Data;
using Project2.Controllers;

namespace Project2.Services

{
    public class ClimateService : IClimateService
    {
        private readonly AppDbContext _context;
        public ClimateService(AppDbContext context)
        {
            _context = context;
        }
        public Climate AddClimate(ClimateDTO climateDTO)
        {
            var climate = new Climate
            {
                ClimateId = climateDTO.ClimateId,
                ClimateType = climateDTO.ClimateType
            };
            _context.Climates.Add(climate);
            _context.SaveChanges();
            return climate;
        }

        public void DeleteClimate(int climateId)
        {
            var climate = _context.Climates.FirstOrDefault(c => c.ClimateId == climateId);
            if (climate != null)
            {
                _context.Climates.Remove(climate);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Climate not found.");
            }
        }

        public IEnumerable<ClimateDTO> GetAllClimates()
        {
            var climates = _context.Climates.Select(c => new ClimateDTO
            {
                ClimateId = c.ClimateId,
                ClimateType = c.ClimateType
            }).ToList();
            return climates;
        }

        public ClimateDTO GetClimateById(int climateId)
        {
            var climate = _context.Climates.Find(climateId);
            if (climate != null)
            {
                var climateDTO = new ClimateDTO
                {
                    ClimateId = climate.ClimateId,
                    ClimateType = climate.ClimateType
                };
                return climateDTO;
            }
            else
            {
                throw new Exception("Climate not found.");
            }
        }

        public ClimateDTO UpdateClimate(int climateId, ClimateDTO updatedClimate)
        {
            var climate = _context.Climates.Find(climateId);
            if (climate == null)
            {
                return null;
            }
            climate.ClimateId = updatedClimate.ClimateId;
            climate.ClimateType = updatedClimate.ClimateType;

            _context.Climates.Update(climate);
            _context.SaveChanges();

            return updatedClimate;
        }
    }
}