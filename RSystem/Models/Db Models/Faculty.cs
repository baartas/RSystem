using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RSystem.Models
{
    public class Faculty
    {
        public int FacultyId { get; set; }

        public string Name { get; set; }
        public string Abbrevation { get; set; }

        public ICollection<Specialization> Specializations { get; set; }
    }
}