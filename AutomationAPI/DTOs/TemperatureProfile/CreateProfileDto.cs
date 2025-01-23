using System.ComponentModel.DataAnnotations;

namespace AutomationAPI.DTOs.TemperatureProfile
{
    public class CreateProfileDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Profile { get; set; }
        public int RoomId { get; set; }
    }
}
