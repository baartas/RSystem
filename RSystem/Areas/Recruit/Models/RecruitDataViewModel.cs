using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using System.Web.Mvc;
using RSystem.Models;

namespace RSystem.ViewModels
{
    public class RecruitDataViewModel
    {
        //List of Countries
        public SelectList Countries { get; set; }

        public int RecruitDataId { get; set; }

        //Recruit Data
        [Display(Name = "Imię")]
        public string FirstName { get; set; }
        [Display(Name = "Drugie imię")]
        public string SecondName { get; set; }
        [Display(Name = "Nazwisko")]
        public string LastName { get; set; }
        [Display(Name = "Płeć")]
        public Sex Sex { get; set; }

        //Identity
        [Display(Name = "Obywatelstwo")]
        public string Citizenship { get; set; }
        [Display(Name = "Dokument Potwierdzający tożsamość")]
        public DocumentType DocumentType { get; set; }
        public string DocumentNumber { get; set; }

        //Adress
        [Display(Name = "Ulica")]
        public string Street { get; set; }
        [Display(Name = "Numer domu")]
        public string House { get; set; }
        [Display(Name = "Numer mieszkania")]
        public string Flat { get; set; }
        [Display(Name = "Kod pocztowy")]
        public string PostalCode { get; set; }
        [Display(Name = "Miasto")]
        public string City { get; set; }
        [Display(Name = "Kraj")]
        public string Country { get; set; }

        //Corespondent Adress
        [Display(Name = "Adres do korespondencji taki sam jak adres zamieszkania")]
        public bool CorespondentAdressSameAsResidence { get; set; }
        [Display(Name = "Ulica")]
        public string CorespondentStreet { get; set; }
        [Display(Name = "Numer domu")]
        public string CorespondentHouse { get; set; }
        [Display(Name = "Numer Mieszkania")]
        public string CorespondentFlat { get; set; }
        [Display(Name = "Kod pocztowy")]
        public string CorespondentPostalCode { get; set; }
        [Display(Name = "Miasto")]
        public string CorespondentCity { get; set; }
        [Display(Name = "Kraj")]
        public string CorespondentCountry { get; set; }

        //E adress
        [EmailAddress(ErrorMessage = "Adress email wygląda na niepoprawny")]
        [Display(Name = "Adres E-mail")]
        public string Email { get; set; }
        [Display(Name = "Numer telefonu")]
        public string Phone { get; set; }

        //Disability
        [Display(Name = "Osoba niepełnosprawna")]
        public bool IsDisabled { get; set; }


        //parents
        [Display(Name = "Imię ojca")]
        public string FathersName { get; set; }
        [Display(Name = "Imię Matki")]
        public string MothersName { get; set; }

        //Place and date of birth
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Data urodzenia")]
        public DateTime DayOfBirth { get; set; }
        [Display(Name = "Miejsce urodzenia")]
        public string BirthCity { get; set; }
        [Display(Name = "Kraj urodzenia")]
        public string BirthCountry { get; set; }

        //Military
        [Display(Name = "Status wojskowy")]
        public MilitaryAttitude MilitaryAttitude { get; set; }

    }
}