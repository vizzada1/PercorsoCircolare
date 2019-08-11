namespace PercorsoCircolare.WebApi.Models
{
    public class RoomVM
    {
        public int RoomId { get; set; }
        public string Name { get; set; }
        public int AvailableSeats { get; set; }
        public bool IsActive { get; set; }
        public BuildingVM Building { get; set; }
    }
}