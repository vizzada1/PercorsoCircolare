using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PercorsoCircolare.Entities
{
    public class Booking
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int BookingId { get; set; }

        [Required] public int ResourceId { get; set; }
        [Required] public string Description { get; set; }
        [Required] public DateTime DateStart { get; set; }
        [Required] public DateTime DateEnd { get; set; }
        [Required] public int RoomId { get; set; }

        public virtual Resource Resource { get; set; }
        public virtual Room Rooms { get; set; }
    }
}