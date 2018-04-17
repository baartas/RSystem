using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RSystem.Models
{
    public class MaturaExam
    {
        public int RecruitEducationId { get; set; }
        public string Name { get; set; }

        public ICollection<MaturaResult> MaturaResults { get; set; }

        public int RecruitId { get; set; }
        public Recruit Recruit { get; set; }
    }
}