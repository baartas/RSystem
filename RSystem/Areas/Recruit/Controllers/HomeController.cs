using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using RSystem.Controllers;
using RSystem.DAL;
using RSystem.Managers;
using RSystem.Models;
using RSystem.ViewModels;

namespace RSystem.Areas.Recruit.Controllers
{
    [Authorize(Roles = "Recruit")]
    public class HomeController : LangBaseController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        //GET: Recruit/Home/Index                     
        public ActionResult Index()
        {
            var user = GetUser();
            var photoPath = Path.Combine(Server.MapPath("~/Content/photos/"), user.UserName + ".png");

            var tilesManager = new TilesStatusManager(user.Id, photoPath);
            var viewModel = tilesManager.GeHomeIndexViewModel();

            return View(viewModel);
        }

        //GET: Recruit/Home/Data
        public ActionResult Data()
        {
            var userId = User.Identity.GetUserId<string>();
            if (userId == null)
                return HttpNotFound();

            Models.Recruit recruit = db.Recruits.First(r => r.ApplicationUserId == userId);
            var data = db.RecruitDatas.First(r => r.RecruitDataId == recruit.RecruitId);

            var toReturn = Mapper.Map<RecruitDataViewModel>(data);
            toReturn.Countries = GetCountries();

            return View(toReturn);
        }

        //POST: Recruit/Home/Data
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Data(RecruitDataViewModel recriutData)
        {

            RecruitData dataInDb = db.RecruitDatas.Find(recriutData.RecruitDataId);
            if (dataInDb == null)
                return HttpNotFound();

            Mapper.Map(recriutData, dataInDb);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        //GET: Recruit/Home/Preference
        public ActionResult Preferences()
        {
            var userId = User.Identity.GetUserId<string>();
            if (userId == null)
                return HttpNotFound();
            Models.Recruit recruit = db.Recruits.First(r => r.ApplicationUserId == userId);
            if (recruit == null)
                return HttpNotFound();

            var preferences = db.RecruitPreferences
                .Include(s => s.Specialization.Faculty)
                .Where(r => r.RecruitId == recruit.RecruitId)
                .OrderBy(p => p.Priority);

            return View(preferences);
        }

        //Remove Preference by id
        //POST:Recruit/Home/Preferences
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Preferences(int? RecruitPreferenceId)
        {
            if (RecruitPreferenceId == null)
                return HttpNotFound();
            var user = GetUser();

            var recruit = db.Recruits
                .First(u => u.ApplicationUserId == user.Id);

            var allowedToRemove = db.RecruitPreferences
                .Where(r => r.RecruitId == recruit.RecruitId);

            //To avoid now allowed user removing preference
            if (!allowedToRemove.Any(r => r.RecruitPreferenceId == RecruitPreferenceId))
                return HttpNotFound();

            //If user is allowed to remove this preference
            var toRemove = db.RecruitPreferences
                .First(r => r.RecruitPreferenceId == RecruitPreferenceId);

            db.RecruitPreferences.Remove(toRemove);
            db.SaveChanges();

            RecruitMenager.RepairPriorityOrder(recruit.RecruitId);

            return RedirectToAction("Preferences");
        }

        //GET: Recruit/Home/AddPreference
        public ActionResult AddPreference()
        {
            var faculties = db.Faculties.Include(s => s.Specializations);
            var model = new Dictionary<Faculty, IEnumerable<Specialization>>();

            foreach (var faculty in faculties)
            {
                if (faculty.Specializations.Any(d => DateTime.Compare(d.Deadline, DateTime.Today) >= 0))
                {
                    model.Add(faculty, faculty.Specializations
                        .Where(d=>DateTime.Compare(d.Deadline,DateTime.Today)>=0)
                        );
                }
            }

            return View(model);
        }

        //POST: Recruit/Home/AddPreference
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddPreference(int? Id)
        {
            if (Id == null)
                return RedirectToAction("Preferences");

            var user = GetUser();
            var recruit = db.Recruits
                .First(u => u.ApplicationUserId == user.Id);

            var priorities = db.RecruitPreferences
                .Where(r => r.RecruitId == recruit.RecruitId);

            //max amount of preferences is 15
            if (priorities.Count() >= 15)                           
                return RedirectToAction("Preferences");
                    
            //Set priority to new preference
            var priority = priorities.Any()
                ? priorities.Max(p => p.Priority) + 1
                : 1;

            //set preference model
            var toAdd = new RecruitPreference()
            {
                RecruitId = recruit.RecruitId,
                Specialization = db.Specializations.First(id => id.SpecializationId == Id),
                Priority = (short)priority
            };

            db.RecruitPreferences.Add(toAdd);
            db.SaveChanges();

            await RecruitMenager.CalculatePointAsync(recruit.RecruitId, (int)Id);

            return RedirectToAction("Preferences");
        }

        //GET: Recruit/Home/Education
        public ActionResult Education()
        {
            var user = GetUser();
            var recruit = db.Recruits
                .Include(r => r.MaturaResults.Select(s => s.MaturaSubject))
                .FirstOrDefault(u => u.ApplicationUserId == user.Id);

            var model = new EducationViewModel()
            {
                MaturaResults = recruit.MaturaResults.ToArray(),
                MaturaType = recruit.MaturaType,
                MaturaNumber = recruit.MaturaNumber,
                DateOfPass = recruit.DateOfPass
            };

            return View(model);
        }

        //POST: Recruit/Home/Education
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Education(EducationViewModel model)
        {
            var user = GetUser();
            var recruit = db.Recruits.FirstOrDefault(u => u.ApplicationUserId == user.Id);
            recruit.DateOfPass = model.DateOfPass;
            recruit.MaturaNumber = model.MaturaNumber;
            recruit.MaturaType = model.MaturaType;

            var toUpdate = db.MaturaResults.Where(r => r.RecruitId == recruit.RecruitId);

            foreach (var fromForm in model.MaturaResults)
            {
                var tmp = toUpdate.FirstOrDefault(m => m.MaturaResultId == fromForm.MaturaResultId);
                if (tmp != null)
                    tmp.Points = fromForm.Points;

            }

            db.SaveChanges();
            RecruitMenager.CalculatePointAsync(recruit.RecruitId);
            return RedirectToAction("Index");
        }

        //GET: Recruit/Home/Photo
        public ActionResult Photo()
        {
            //Default path to photos
            var path = "~/Content/photos/";
            var pesel = GetUser().UserName;

            ViewBag.Photo = "Zmień";
            if (System.IO.File.Exists(Path.Combine(Server.MapPath("~/Content/photos/"), pesel + ".png")))
                return View(model: path + pesel + ".png");

            ViewBag.Photo = "Dodaj";
            return View(model: path + "default-user-men.png");

            //return View(model: "default-user-girl-women.png");
        }

        //POST: Recruit/Home/Photo
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Photo(HttpPostedFileBase photo)
        {
            if (photo != null)
            {
                //var fileExtension = Path.GetExtension(photo.FileName);
                var pesel = GetUser().UserName;
                var path = Path.Combine(
                    Server.MapPath("~/Content/photos/"), pesel + ".png");
                photo.SaveAs(path);
            }
            return RedirectToAction("Index");
        }
        private ApplicationUser GetUser()
        {
            return System.Web.HttpContext
                .Current.GetOwinContext()
                .GetUserManager<ApplicationUserManager>()
                .FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
        }

        private SelectList GetCountries()
        {
            List<string> countries = new List<string>();
            CultureInfo[] culturesInfo = CultureInfo.GetCultures(CultureTypes.SpecificCultures);

            foreach (CultureInfo cultureInfo in culturesInfo)
            {
                RegionInfo region = new RegionInfo(cultureInfo.LCID);
                if (!countries.Contains(region.NativeName))
                    countries.Add(region.NativeName);
            }
            countries.Sort();

            var selectList = new SelectList(countries);
            return selectList;
        }
    }
}