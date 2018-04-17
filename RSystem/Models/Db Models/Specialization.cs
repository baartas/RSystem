using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RSystem.Models
{

    public class Specialization
    {
        public int SpecializationId { get; set; }

        [Required(ErrorMessage = "Nazwa kierunku jest wymagana.")]
        [Display(Name = "Nazwa kierunku.")]
        public string Name { get; set; }

        [Display(Name = "Opis.")]
        public string Description { get; set; }

        [Display(Name = "Opłata")]
        [Required(ErrorMessage = "Opłata rekrutacyjna jest wymagana.")]
        public float Price { get; set; }

        public ICollection<PointsMultipiler> PointsMultipilers { get; set; }
        [Required(ErrorMessage = "Termin zakończenia rekrutacji jest wymagany.")]
        [Display(Name = "Termin zakończenia.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Deadline { get; set; }

        [Required(ErrorMessage = "Wydział jest wymagany.")]
        public int FacultyId { get; set; }
        public Faculty Faculty { get; set; }

        [Required(ErrorMessage = "Limit miejsc jest wymagany")]
        [Display(Name = "Limit miejsc")]
        public int LimitOfPlaces { get; set; }
    
        public ICollection<RecruitPreference> RecruitPreferences { get; set; }

        public ICollection<Recruit> AcceptedRecruits { get; set; }
        
    }
}