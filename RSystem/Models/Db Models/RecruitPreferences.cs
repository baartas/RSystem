using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RSystem.Models
{
    public enum RecrutationStatus
    {
        Standby,
        Rejected,
        Accepted
    }

    public class RecruitPreference
    {
        public int RecruitPreferenceId { get; set; }

        public int SpecializationId { get; set; }
        public Specialization Specialization { get; set; }

        [Range(1,20)]
        [Display(Name = "Priorytet")]
        public short Priority { get; set; }

        public RecrutationStatus Status { get; set; }

        [Display(Name = "Punkty")]
        public short Points{ get; set; }

        [Display(Name = "Czy opłacony?")]
        public bool Paid { get; set; }

        public int RecruitId { get; set; }
        public Recruit Recruit { get; set; }

        public RecruitPreference()
        {
            this.Status = RecrutationStatus.Standby;
            Paid = false;
        }
    }
}