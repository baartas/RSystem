using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using RSystem.App_LocalResources.Recruit;
using RSystem.DAL;
using RSystem.Models;
using RSystem.ViewModels;

namespace RSystem.Managers
{
    public class TilesStatusManager
    {
        private ApplicationDbContext db;
        private Recruit recruit;
        private string photoPath;

        private readonly string Done = "tile-done";
        private readonly string Empty = "tile-empty";
        //private readonly string Incomplete = "tile-incomplete";

        private string getPhotoStatus()
        {
            return System.IO.File.Exists(this.photoPath)
                ? Done
                : Empty;
        }

        private string getDataStatus()
        {
            //Get all required properties which are strings
            var properties = typeof(RecruitData).GetProperties()
                .Where( p=>p.PropertyType.Name ==typeof(string).Name &&                       
                        p.Name != "SecondName" &&
                        p.Name != "Flat" &&
                        p.Name != "CorespondentFlat"
                    );

            //Filter properties if corespondent adress is not same as residence
            if (recruit.RecriutData.CorespondentAdressSameAsResidence)
                properties = properties.Where(p => !p.Name.StartsWith("Corespondent"));

            foreach (var propertyInfo in properties)
            {
                var propertyValue = propertyInfo.GetValue(recruit.RecriutData) as string;
                
                if (string.IsNullOrWhiteSpace(propertyValue))
                    return Empty;
            }
            
            //Return Done if pass
            return Done;
        }

        private string getEducationStatus()
        {
            return !string.IsNullOrWhiteSpace(recruit.MaturaNumber) 
                ? Done 
                : Empty;
        }

        private string getPreferencesStatus()
        {
            return recruit.RecruitPreferences.Any()
                ? Done 
                : Empty;
        }

        private string getGreeting()
        {
            var hello = Home.Hello;
            return string.IsNullOrWhiteSpace(recruit.RecriutData.FirstName)
                ? hello
                : hello+", "+ recruit.RecriutData.FirstName;
        }

        public HomeIndexViewModel GeHomeIndexViewModel()
        {
            return new HomeIndexViewModel()
            {
                DataStatus = this.getDataStatus(),
                PhotoStatus = this.getPhotoStatus(),
                EducationStatus = getEducationStatus(),
                PreferenceStatus = this.getPreferencesStatus(),
                Greeting = this.getGreeting()
            };
        }

        public TilesStatusManager(string userId,string photoPath)
        {
            this.db=new ApplicationDbContext();

            this.recruit = db.Recruits
                .Include(r=>r.RecriutData)
                .Include(p=>p.RecruitPreferences)
                .FirstOrDefault(id=>id.ApplicationUser.Id==userId);

            this.photoPath = photoPath;
        }

    }
}