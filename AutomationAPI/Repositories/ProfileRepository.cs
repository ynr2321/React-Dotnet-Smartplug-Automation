using AutomationAPI.Data;
using AutomationAPI.DTOs.TemperatureProfile;
using AutomationAPI.Interfaces;
using AutomationAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AutomationAPI.Repositories
{
    /// <summary>
    /// Encapsulates logic for interacting with temperature profiles in the selected database
    /// </summary>
    public class ProfileRepository : IProfileRepository
    {
        /// <summary>
        /// The application database context used for data operations.
        /// </summary>
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProfileRepository"/> class.
        /// </summary>
        /// <param name="context">The application database context used for data operations.</param>
        public ProfileRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <inheritdoc />
        public async Task<List<TemperatureProfile>> GetAllAsync()
        {
            // Get profiles dbset as queryable
            var profiles = _context.Profiles.AsQueryable();

            // Order newest to oldest
            profiles = profiles.OrderByDescending(p => p.CreatedDate);

            return await profiles.ToListAsync();
        }

        /// <inheritdoc />
        public async Task<TemperatureProfile?> GetByIdAsync(int id)
        {
            return await _context.Profiles.FirstOrDefaultAsync(p => p.ProfileId == id);
        }

        /// <inheritdoc />
        public async Task<TemperatureProfile> CreateAsync(TemperatureProfile profileModel)
        {
            await _context.AddAsync(profileModel);
            await _context.SaveChangesAsync();
            return profileModel;
        }

        /// <inheritdoc />
        public async Task<TemperatureProfile?> UpdateAsync(int id, UpdateProfileRequestDto updateDto)
        {
            // Find profile
            var profileToUpdate = await _context.Profiles.FirstOrDefaultAsync(p => p.ProfileId == id);

            // Return null if doesn't exist
            if (profileToUpdate == null)
                return null;

            // Else, track changes and execute them
            profileToUpdate.ModifiedDate = DateTime.Now;
            profileToUpdate.Name = updateDto.Name;
            profileToUpdate.RoomId = updateDto.RoomId;
            profileToUpdate.Profile = updateDto.Profile;
            await _context.SaveChangesAsync();

            return profileToUpdate;
        }

        /// <inheritdoc />
        public async Task<TemperatureProfile?> DeleteAsync(int id)
        {
            // Find profile
            var profileToDelete = await _context.Profiles.FirstOrDefaultAsync(p => p.ProfileId == id);

            // Return null if first or default is null
            if (profileToDelete == null)
                return null;

            // Else, modify the db
            _context.Profiles.Remove(profileToDelete);
            await _context.SaveChangesAsync();
            return profileToDelete;
        }

        /// <inheritdoc />
        public async Task<bool> ProfileExists(int id)
        {
            return await _context.Profiles.AnyAsync(p => p.ProfileId == id);
        }
    }
}