using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PercorsoCircolare.Entities
{
    public class Resource
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)][Required] public int ResourceId { get; set; }

        [MaxLength(8)] [Required] public string Username { get; set; }

        [Required] public string FirstName { get; set; }

        [Required] public string LastName { get; set; }

        [Required] public string EmailAddress { get; set; }

        [Required] public bool IsActive { get; set; }
    }
}