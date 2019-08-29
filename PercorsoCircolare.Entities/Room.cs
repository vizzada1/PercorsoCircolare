using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PercorsoCircolare.Entities
{
    public class Room
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int RoomId { get; set; }

        [Required] public string Name { get; set; }
        [Required] public int AvailableSeats { get; set; }
        [Required] public bool IsActive { get; set; }
        [Required] public int BuildingId { get; set; }

        public virtual Building Building { get; set; }
    }
}