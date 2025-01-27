using AutomationAPI.Models;

namespace AutomationAPI.Repositories
{
    public interface IProfileRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Task<List<TemperatureProfile>> GetAllAsync();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<TemperatureProfile?> GetByIdAsync(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="profileModel"></param>
        /// <returns></returns>
        public Task<TemperatureProfile> CreateAsync(TemperatureProfile profileModel);

        //public Task<TemperatureProfile?> UpdateAsync(int id, UpdateProfileRequestDto stockDto);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<TemperatureProfile?> DeleteAsync(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<bool> ProfileExists(int id);
    }
}