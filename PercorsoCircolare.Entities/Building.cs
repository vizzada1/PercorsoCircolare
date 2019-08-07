using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PercorsoCircolare.DAL.Entities
{
    public class Building
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int BuildingId { get; set; }

        [Required] public string Name { get; set; }

        [Required] public string Address { get; set; }

        [Required] public bool IsActive { get; set; }
    }
}