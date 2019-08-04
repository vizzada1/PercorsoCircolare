using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PercorsoCircolare.DAL.Entities
{
    public class Resource
    {
        public int ResourceId { get; set; }
        [MaxLength(8)]
        [Required]
        public string Username { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string EmailAddress { get; set; }
        [Required]
        public bool IsActive { get; set; }
    }
}
