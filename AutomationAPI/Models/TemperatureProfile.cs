namespace AutomationAPI.Models
{
    public class TemperatureProfile
    {
        public int ProfileId { get; set; } 
        public DateTime CreatedDate { get; set; }
        public string Name { get; set; }
        public string Profile { get; set; }
        public DateTime ModifiedDate { get; private set; }
    }
}
