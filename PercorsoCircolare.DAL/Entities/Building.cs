using System.ComponentModel.DataAnnotations;

namespace PercorsoCircolare.DAL.Entities
{
    public class Building
    {
        [Required] public int BuildingId { get; set; }

        [Required] public string Name { get; set; }

        [Required] public string Address { get; set; }

        [Required] public bool IsActive { get; set; }
    }
}