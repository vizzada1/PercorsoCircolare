namespace PercorsoCircolare.WebApi.Models
{
    public class ResourceVM
    {
        public int ResourceId { get; set; }

        public string Username { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string EmailAddress { get; set; }

        public bool IsActive { get; set; }
    }
}