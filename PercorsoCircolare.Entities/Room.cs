using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PercorsoCircolare.DAL.Entities
{
    public class Room
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int RoomId { get; set; }

        [Required] public string Name { get; set; }
        [Required] public int AvailableSeats { get; set; }
        [Required] public bool IsActive { get; set; }
        [Required] public Building Building { get; set; }
    }
}