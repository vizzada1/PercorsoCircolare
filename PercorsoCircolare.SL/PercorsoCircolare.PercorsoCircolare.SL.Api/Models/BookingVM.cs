using System;

namespace PercorsoCircolare.PercorsoCircolare.SL.Api.Models
{
    public class BookingVM
    {
        public int BookingId { get; set; }
        public ResourceVM Resource { get; set; }
        public string Description { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
    }
}