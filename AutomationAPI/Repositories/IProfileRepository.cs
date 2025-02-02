using AutomationAPI.DTOs.TemperatureProfile;
using AutomationAPI.Models;

namespace AutomationAPI.Repositories
{
    public interface IProfileRepository
    {
        /// <summary>
        /// Retrieves all temperature profiles.
        /// </summary>
        /// <returns>A list of temperature profiles.</returns>
        public Task<List<TemperatureProfile>> GetAllAsync();

        /// <summary>
        /// Retrieves a temperature profile by its ID.
        /// </summary>
        /// <param name="id">The ID of the profile.</param>
        /// <returns>The matching temperature profile or null if not found.</returns>
        public Task<TemperatureProfile?> GetByIdAsync(int id);

        /// <summary>
        /// Creates a new temperature profile.
        /// </summary>
        /// <param name="profileModel">The profile data to create.</param>
        /// <returns>The created temperature profile.</returns>
        public Task<TemperatureProfile> CreateAsync(TemperatureProfile profileModel);

        /// <summary>
        /// Updates an existing temperature profile.
        /// </summary>
        /// <param name="id">The ID of the profile to update.</param>
        /// <param name="stockDto">The updated profile data.</param>
        /// <returns>The updated temperature profile or null if not found.</returns>
        public Task<TemperatureProfile?> UpdateAsync(int id, UpdateProfileRequestDto stockDto);

        /// <summary>
        /// Deletes a temperature profile by its ID.
        /// </summary>
        /// <param name="id">The ID of the profile to delete.</param>
        /// <returns>The deleted temperature profile or null if not found.</returns>
        public Task<TemperatureProfile?> DeleteAsync(int id);

        /// <summary>
        /// Checks if a temperature profile exists.
        /// </summary>
        /// <param name="id">The ID of the profile.</param>
        /// <returns>True if the profile exists, otherwise false.</returns>
        public Task<bool> ProfileExists(int id);

    }
}