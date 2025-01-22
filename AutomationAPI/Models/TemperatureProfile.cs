using System.ComponentModel.DataAnnotations;

namespace AutomationAPI.Models
{
    public class TemperatureProfile
    {
        [Key]
        public int ProfileId { get; set; } 
        public string Name { get; set; }
        public string Profile { get; set; }
        public int RoomId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; private set; }
    }
}
