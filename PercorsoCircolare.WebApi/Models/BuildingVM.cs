﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PercorsoCircolare.WebApi.Models
{
    public class BuildingVM
    {
        public int BuildingId { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public bool IsActive { get; set; }
    }
}