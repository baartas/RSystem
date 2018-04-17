using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using RSystem.DAL;

namespace RSystem.Models
{
    public class Recruit
    {
        public int RecruitId { get; set; }

        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public ICollection<MaturaResult> MaturaResults { get; set; }

        public MaturaType MaturaType { get; set; }

        public string MaturaNumber { get; set; }
        public DateTime DateOfPass { get; set; }

        public RecruitData RecriutData { get; set; }
        public ICollection<RecruitPreference> RecruitPreferences { get; set; }

        public Specialization AcceptedSpecialization { get; set; }
    }
}