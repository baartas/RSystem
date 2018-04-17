using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using RSystem.Models;

namespace RSystem.ViewModels
{
    public class EducationViewModel
    {   
        public MaturaResult[] MaturaResults { get; set; }
        public MaturaType MaturaType { get; set; }
        [Display(Name = "Data zdania matury")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfPass { get; set; }
        [Display(Name = "Numer zdanej matury")]
        public string MaturaNumber { get; set; }
    }
}