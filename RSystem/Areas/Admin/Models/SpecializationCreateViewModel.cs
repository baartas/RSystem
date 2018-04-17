using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RSystem.Models;

namespace RSystem.Areas.Admin.Models
{
    public class SpecializationCreateViewModel
    {
        public Specialization Specialization { get; set; }
        public IEnumerable<MaturaSubject> MaturaSubjects { get; set; }        
        public IEnumerable<PointsMultipiler> PointsMultipilers { get; set; }
        public SelectList Faculties { get; set; }
    }
}