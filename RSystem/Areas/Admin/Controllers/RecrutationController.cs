using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RSystem.DAL;
using RSystem.Managers;
using RSystem.Models;

namespace RSystem.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RecrutationController : Controller
    {
        private ApplicationDbContext db=new ApplicationDbContext();

        // GET: Admin/Recrutation        
        public ActionResult Index()
        {
            var model = new Dictionary<Faculty, IEnumerable<Specialization>>();
            var faculties = db.Faculties.Include(s=>s.Specializations)
                .OrderBy(s => s.Abbrevation);

            foreach (var faculty in faculties)
            {
                if (faculty.Specializations.Any())
                {
                    model.Add(faculty, faculty.Specializations
                        .OrderBy(s => s.Name));
                }
            }
            @ViewBag.HideMainHeader = true;
            return View(model);
        }

        // GET: Admin/Recruitation/StudentsList
        public ActionResult StudentsList(int specializationId)
        {
            var specialization = db.Specializations.Include(r=>r.AcceptedRecruits)
                .FirstOrDefault(id => id.SpecializationId == specializationId);

            if (specialization == null)
                return HttpNotFound();

            var model =new List<KeyValuePair<RSystem.Models.Recruit,int>>();

            var acceptedRecruits = specialization.AcceptedRecruits;

            foreach (var recruit in acceptedRecruits)
            {
                var points = db.RecruitPreferences
                    .First(r => r.Recruit.RecruitId == recruit.RecruitId &&
                                r.SpecializationId == specializationId)
                    .Points;

                model.Add(new KeyValuePair<RSystem.Models.Recruit, int>(recruit,points));
            }
            ViewBag.SpecializationName = specialization.Name;
            
           return View(model.OrderBy(val=>val.Value).ToList());          
        }

        // GET: Admin/Recrutation/ChooseSpecialization
        public ActionResult ChooseSpecialization()
        {
            var faculties = db.Faculties.Include(s => s.Specializations);
            var model = new Dictionary<Faculty, IEnumerable<Specialization>>();

            foreach (var faculty in faculties)
            {
                if (faculty.Specializations.Any(d => DateTime.Compare(d.Deadline, DateTime.Today) == -1))
                {
                    model.Add(faculty, faculty.Specializations
                        .Where(d => DateTime.Compare(d.Deadline, DateTime.Today) == -1));
                }
            }

            return View(model);
        }

        [HttpPost]
        // POST: Admin/Recrutation/ChooseSpecialization
        public ActionResult ChooseSpecialization(IEnumerable<int> listOfId)
        {
            if (listOfId != null)
                RecrutationManager.RecruitBySpecializations(listOfId);

            return RedirectToAction("Index","Recrutation",new{area="Admin"});
        }
    }
}