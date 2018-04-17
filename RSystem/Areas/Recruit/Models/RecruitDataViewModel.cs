using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Web.Mvc;
using RSystem.Models;
using RSystem.App_LocalResources.Recruit.Data;

namespace RSystem.ViewModels
{
    public class RecruitDataViewModel
    {
        //List of Countries
        public SelectList Countries { get; set; }

        public int RecruitDataId { get; set; }

        //Recruit Data
        [Display(Name = "Firstname",ResourceType = typeof(Data))]
        public string FirstName { get; set; }
        [Display(Name = "SecondName",ResourceType = typeof(Data))]
        public string SecondName { get; set; }
        [Display(Name = "LastName",ResourceType = typeof(Data))]
        public string LastName { get; set; }
        [Display(Name = "Sex",ResourceType = typeof(Data))]
        public Sex Sex { get; set; }

        //Identity
        [Display(Name = "Citizenship", ResourceType = typeof(Data))]
        public string Citizenship { get; set; }
        [Display(Name = "DocumentType",ResourceType = typeof(Data))]
        public DocumentType DocumentType { get; set; }
        public string DocumentNumber { get; set; }

        //Adress
        [Display(Name = "Street", ResourceType = typeof(Data))]
        public string Street { get; set; }
        [Display(Name = "House", ResourceType = typeof(Data))]
        public string House { get; set; }
        [Display(Name = "Flat", ResourceType = typeof(Data))]
        public string Flat { get; set; }
        [Display(Name = "PostalCode", ResourceType = typeof(Data))]
        public string PostalCode { get; set; }
        [Display(Name = "City", ResourceType = typeof(Data))]
        public string City { get; set; }
        [Display(Name = "Country", ResourceType = typeof(Data))]
        public string Country { get; set; }

        //Corespondent Adress
        [Display(Name = "CorespondentAdressSameAsResidence", ResourceType = typeof(Data))]
        public bool CorespondentAdressSameAsResidence { get; set; }
        [Display(Name = "CorespondentStreet", ResourceType = typeof(Data))]
        public string CorespondentStreet { get; set; }
        [Display(Name = "CorespondentHouse", ResourceType = typeof(Data))]
        public string CorespondentHouse { get; set; }
        [Display(Name = "CorespondentFlat",ResourceType = typeof(Data))]
        public string CorespondentFlat { get; set; }
        [Display(Name = "CorespondentPostalCode", ResourceType = typeof(Data))]
        public string CorespondentPostalCode { get; set; }
        [Display(Name = "CorespondentCity", ResourceType = typeof(Data))]
        public string CorespondentCity { get; set; }
        [Display(Name = "CorespondentCountry", ResourceType = typeof(Data))]
        public string CorespondentCountry { get; set; }
 
        //E adress
        [EmailAddress(ErrorMessage = "Adress email wygląda na niepoprawny")]
        [Display(Name = "Adres E-mail")]
        public string Email { get; set; }
        [Display(Name = "Phone",ResourceType = typeof(Data))]
        public string Phone { get; set; }

        //Disability
        [Display(Name = "IsDisabled", ResourceType = typeof(Data))]
        public bool IsDisabled { get; set; }

        //parents
        [Display(Name = "FathersName", ResourceType = typeof(Data))]
        public string FathersName { get; set; }
        [Display(Name = "MothersName", ResourceType = typeof(Data))]
        public string MothersName { get; set; }

        //Place and date of birth
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "DayOfBirth", ResourceType = typeof(Data))]
        public DateTime DayOfBirth { get; set; }
        [Display(Name = "BirthCity", ResourceType = typeof(Data))]
        public string BirthCity { get; set; }
        [Display(Name = "Country",ResourceType = typeof(Data))]
        public string BirthCountry { get; set; }

        //Military
        [Display(Name = "MilitaryAttitude", ResourceType = typeof(Data))]
        public MilitaryAttitude MilitaryAttitude { get; set; }

    }
}