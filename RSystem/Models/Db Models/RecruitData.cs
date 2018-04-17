using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace RSystem.Models
{

    #region Enums

    public enum Sex
    {
        [Display(Name = "Mężczyzna")]
        Male,
        [Display(Name = "Kobieta")]
        Female
    }

    public enum DocumentType
    {
        [Display(Name = "Paszport")]
        Passport,
        [Display(Name = "Dowód osobisty")]
        ID
    }

    public enum MilitaryAttitude
    {
        [Display(Name = "Nie dotyczy")]
        NotRequired,
        [Display(Name = "Zwolniony")]
        Released,
        [Display(Name="Przedpoborowy")]
        Before,
        [Display(Name="Inny")]
        Other,
        [Display(Name="Poborowy kat. A")]
        A,
        [Display(Name="Poborowy kat. B")]
        B,
        [Display(Name="Poborowy kat. D")]
        D,
        [Display(Name="Poborowy kat. E")]
        E,
        [Display(Name="W rezerwie")]
        Reserve,
        [Display(Name="W czynnej służbie")]
        Service
    }


    #endregion
    public class RecruitData
    {
        public int RecruitDataId { get; set; }

        public int RecruitId { get; set; }
        public Recruit Recruit { get; set; }

        //Recruit Data
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public Sex Sex { get; set; }

        //Identity
        public string Citizenship { get; set; }
        public DocumentType DocumentType { get; set; }
        public string DocumentNumber { get; set; }

        //Adress
        public string Street { get; set; }
        public string House { get; set; }
        public string Flat { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        //Corespondent Adress
        public bool CorespondentAdressSameAsResidence { get; set; }
        public string CorespondentStreet { get; set; }
        public string CorespondentHouse { get; set; }
        public string CorespondentFlat { get; set; }
        public string CorespondentPostalCode { get; set; }
        public string CorespondentCity { get; set; }
        public string CorespondentCountry { get; set; }

        //E adress
        [EmailAddress(ErrorMessage = "Adress email wygląda na niepoprawny")]
        public string Email { get; set; }
        public string Phone { get; set; }

        //Disability
        public bool IsDisabled { get; set; }


        //parents
        public string FathersName { get; set; }
        public string MothersName { get; set; }

        //Place and date of birth
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DayOfBirth { get; set; }
        public string BirthCity { get; set; }
        public string BirthCountry { get; set; }

        //Military
        public MilitaryAttitude MilitaryAttitude { get; set; }

        public RecruitData()
        {
            DayOfBirth = DateTime.Now;
            CorespondentAdressSameAsResidence = true;
            Country = "Polska";
            BirthCountry = "Polska";
            CorespondentCountry = "Polska";
            IsDisabled = false;
            DocumentType = DocumentType.ID;
            Sex = Sex.Female;
        }
    }
}