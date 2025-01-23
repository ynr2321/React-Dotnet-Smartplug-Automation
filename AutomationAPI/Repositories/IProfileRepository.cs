using AutomationAPI.Models;

namespace AutomationAPI.Repositories
{
    public interface IProfileRepository
    {
        Task<List<TemperatureProfile>> GetAllAsync();
        Task<TemperatureProfile?> GetByIdAsync(int id);
        Task<TemperatureProfile> CreateAsync(TemperatureProfile profileModel);

        //Task<TemperatureProfile?> UpdateAsync(int id, UpdateProfileRequestDto stockDto);
        Task<TemperatureProfile?> DeleteAsync(int id);
        Task<bool> ProfileExists(int id);
    }
}
