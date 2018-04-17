using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RSystem.Models
{
    public class PointsMultipiler
    {
        public int PointsMultipilerId { get; set; }

        public int SpecializationId { get; set; }
        public Specialization Specialization { get; set; }

        public int MaturaSubjectId { get; set; }
        public MaturaSubject MaturaSubject { get; set; }

        public float Multipiler { get; set; }
    }
}