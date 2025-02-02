using System.ComponentModel.DataAnnotations;

namespace AutomationAPI.DTOs.TemperatureProfile
{
    public class UpdateProfileRequestDto
    {
        [Required]
        [MinLength(2, ErrorMessage = "Temperature Profile name must have more than 1 character.")]
        [MaxLength(35, ErrorMessage = "Temperature Profile name can have no more than 35 characters.")]
        public string Name { get; set; }
        [Required]
        public string Profile { get; set; }
        public int RoomId { get; set; }
    }
}
