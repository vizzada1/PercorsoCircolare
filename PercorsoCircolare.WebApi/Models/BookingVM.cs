using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PercorsoCircolare.WebApi.Models
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