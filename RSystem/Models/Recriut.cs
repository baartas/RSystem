using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace RSystem.Models
{

    #region Enums

    public enum Sex
    {
        [Description("Mężczyzna")]
        Male,
        [Description("Kobieta")]
        Female
    }

    public enum MilitaryAttitude
    {
        [Description("Nie dotyczy")]
        NotRequired,
        [Description("Zwolniony")]
        Released,
        [Description("Przedpoborowy")]
        Before,
        [Description("Inny")]
        Other,
        [Description("Poborowy kat. A")]
        A,
        [Description("Poborowy kat. B")]
        B,
        [Description("Poborowy kat. D")]
        D,
        [Description("Poborowy kat. E")]
        E,
        [Description("W rezerwie")]
        Reserve,
        [Description("W czynnej służbie")]
        Service
    }


    #endregion
    public class Recriut
    {
        //Recruit Data
        public string Name { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        //Sex is required

        //parents
        public string FathersName { get; set; }
        public string MothersName { get; set; }

        //Place and date of birth
        public DateTime DayOfBirth { get; set; }
        public string BirthCity { get; set; }

        //Military
        public MilitaryAttitude MilitaryAttitude { get; set; }


    }
}