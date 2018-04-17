using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RSystem.Models;

namespace RSystem.ViewModels
{
    public class PreferencesViewModel
    {
        public int RecruitId { get; set; }

        public IEnumerable<RecruitPreference> Preferences { get; set; }

    }
}