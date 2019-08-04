using System.ComponentModel.DataAnnotations;

namespace PercorsoCircolare.DAL.Entities
{
    public class Resource
    {
        public int ResourceId { get; set; }

        [MaxLength(8)] [Required] public string Username { get; set; }

        [Required] public string FirstName { get; set; }

        [Required] public string LastName { get; set; }

        [Required] public string EmailAddress { get; set; }

        [Required] public bool IsActive { get; set; }
    }
}