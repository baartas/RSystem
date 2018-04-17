using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Ajax.Utilities;
using RSystem.Models;

namespace RSystem.ViewModels
{
    
    public class HomeIndexViewModel
    {
        public string Greeting { get; set; }

        public string DataStatus { get; set; }

        public string PhotoStatus { get; set; }

        public string EducationStatus { get; set; }

        public string PreferenceStatus { get; set; }

    }
}