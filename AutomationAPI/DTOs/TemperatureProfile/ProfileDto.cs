namespace AutomationAPI.DTOs.TemperatureProfile
{
    public class ProfileDto
    {
        public int ProfileId { get; set; }
        public string Name { get; set; }
        public string Profile { get; set; }
        public int RoomId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
