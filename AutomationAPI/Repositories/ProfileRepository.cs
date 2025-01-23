using AutomationAPI.Data;
using AutomationAPI.Models;

namespace AutomationAPI.Repositories
{
    /// <summary>
    /// Encapsulates logic for interacting with profiles in the selected database
    /// </summary>
    public class ProfileRepository : IProfileRepository
    {
        private readonly ApplicationDbContext _context;

        public ProfileRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<List<TemperatureProfile>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<TemperatureProfile?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<TemperatureProfile> CreateAsync(TemperatureProfile profileModel)
        {
            throw new NotImplementedException();
        }

        public Task<TemperatureProfile?> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ProfileExists(int id)
        {
            throw new NotImplementedException();
        }
    }
}
