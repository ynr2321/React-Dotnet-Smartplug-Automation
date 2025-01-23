using AutomationAPI.DTOs.TemperatureProfile;
using AutomationAPI.Models;

namespace AutomationAPI.Mappers
{
    /// <summary>
    /// Static class that provides extension methods to convert between the TemperatureProfile model and its DTOs
    /// </summary>
    public static class ProfileMappers
    {
        public static ProfileDto ToProfileDto(this TemperatureProfile profileModel)
        {
            return new ProfileDto()
            {
                ProfileId = profileModel.ProfileId,
                Name = profileModel.Name,
                Profile = profileModel.Profile,
                RoomId = profileModel.RoomId,
                CreatedDate = profileModel.CreatedDate,
                ModifiedDate = profileModel.ModifiedDate
            };
        }

        public static TemperatureProfile ToProfileFromCreateDto(this CreateProfileDto createDto)
        {
            var creationDate = DateTime.Now;
            return new TemperatureProfile
            {
                Name = createDto.Name,
                Profile = createDto.Profile,
                RoomId = createDto.RoomId,
                CreatedDate = creationDate,
                ModifiedDate = creationDate
            };
        }
    }
}
