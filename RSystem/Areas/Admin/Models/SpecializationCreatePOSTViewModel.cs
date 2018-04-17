using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RSystem.Models;

namespace RSystem.Areas.Admin.Models
{
    public class SpecializationCreatePOSTViewModel
    {
        public Specialization Specialization { get; set; }
        public string MultipilersJSON { get; set; }
    }
}