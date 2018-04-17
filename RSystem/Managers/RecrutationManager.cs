using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Microsoft.Ajax.Utilities;
using RSystem.DAL;
using RSystem.Models;
using WebGrease.Css.Extensions;

namespace RSystem.Managers
{
    public class RecrutationManager
    {
        public static void RecruitBySpecializations(IEnumerable<int>specializationsId)
        {
            var db = new ApplicationDbContext();

            //get all recruits, that  contains at
            //least one of selected specialization
            var recruits = db.Recruits
                .Include(p=>p.RecruitPreferences)
                .Include(m=>m.MaturaResults)
                .Where(r => r.RecruitPreferences
                    .Any(s => specializationsId.Contains(s.SpecializationId)));

            //new list with Recruits and specialization left
            var recrutationList=new List<KeyValuePair<Recruit,int>>();
            foreach (var recruit in recruits)
            {
                var filteredPreferences = recruit.RecruitPreferences
                    .Where(r => specializationsId.Contains(r.SpecializationId))
                    .OrderBy(p=>p.Priority);
                
                recrutationList.Add(new KeyValuePair<Recruit, int>(recruit,filteredPreferences.Count()));
            }

            //Final list
            var finalList=new List<Specialization>(
                        db.Specializations
                        .Where(id=>specializationsId.Contains(id.SpecializationId)));
        

        }
    }
}