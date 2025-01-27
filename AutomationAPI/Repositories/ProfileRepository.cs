using AutomationAPI.Data;
using AutomationAPI.Models;
using Microsoft.EntityFrameworkCore;

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


        public async Task<List<TemperatureProfile>> GetAllAsync()
        {
            // Get profiles dbset as queryable
            var profiles = _context.Profiles.AsQueryable();

            // Order newest to oldest
            profiles = profiles.OrderByDescending(p => p.CreatedDate);

            return await profiles.ToListAsync();
        }

        public async Task<TemperatureProfile?> GetByIdAsync(int id)
        {
            return await _context.Profiles.FirstOrDefaultAsync(p => p.ProfileId == id);
        }

        public async Task<TemperatureProfile> CreateAsync(TemperatureProfile profileModel)
        {
            await _context.AddAsync(profileModel);
            await _context.SaveChangesAsync();
            return profileModel;
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