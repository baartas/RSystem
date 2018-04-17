using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RSystem.Models
{
    public class MaturaResult
    {
        public int MaturaResultId { get; set; }

        [Display(Name = "Punkty")]
        public float Points { get; set; }

        public int MaturaSubjectId { get; set; }
        public MaturaSubject MaturaSubject { get; set; }

        public int RecruitId { get; set; }
        public Recruit Recruit { get; set; }
    }
}