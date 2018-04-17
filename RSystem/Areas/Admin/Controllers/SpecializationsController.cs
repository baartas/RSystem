using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RSystem.Areas.Admin.Models;
using RSystem.DAL;
using RSystem.Managers;
using RSystem.Models;

namespace RSystem.Areas.Admin.Controllers
{   
    [Authorize(Roles = "Admin")]    
    public class SpecializationsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Specializations       
        public ActionResult Index()
        {
            var model = new Dictionary<Faculty, IEnumerable<Specialization>>();
            var faculties = db.Faculties.Include(s => s.Specializations)
                .OrderBy(s=>s.Abbrevation);            

            foreach (var faculty in faculties)
            {
                if (faculty.Specializations.Any())
                {
                    model.Add(faculty, faculty.Specializations
                        .OrderBy(s=>s.Name));
                }
            }

            return View(model);
        }
        
        // GET: Specializations/Create
        public ActionResult Create(int? id)
        {            
            ViewBag.Title = id==null?
                "Dodaj Kierunek":
                "Edytuj Kierunek";

            var viewModel = new SpecializationCreateViewModel()
            {
                PointsMultipilers =
                    db.PointsMultipilers.Include(ms => ms.MaturaSubject).Where(s => s.SpecializationId == id),
                Faculties = new SelectList(db.Faculties, "FacultyId", "Name"),
                MaturaSubjects = db.MaturaSubjects,
                Specialization = db.Specializations.FirstOrDefault(i => i.SpecializationId == id)

            };
            return View(viewModel);                       
        }

        // POST: Specializations/Create        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SpecializationCreatePOSTViewModel model)
        {
            //SpecializationId is null while creating            
            ModelState["Specialization.SpecializationId"].Errors.Clear();

            if (ModelState.IsValid)
            {
                var specialization = model.Specialization;

                var multipilers = new List<PointsMultipiler>();

                if (!string.IsNullOrWhiteSpace(model.MultipilersJSON))
                    multipilers = JSONParserManager
                        .JsonToPointsMultipilers(model.MultipilersJSON, model.Specialization.SpecializationId)
                        .ToList();

                if (specialization.SpecializationId == 0)
                {
                    specialization.PointsMultipilers = multipilers;
                    db.Specializations.Add(specialization);                    
                }
                else
                {
                    foreach (var multipiler in multipilers)
                        db.PointsMultipilers.Add(multipiler);
                    db.Entry(specialization).State = EntityState.Modified;                    
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(new SpecializationCreateViewModel
            {
                Specialization = model.Specialization,
                Faculties = new SelectList(db.Faculties, "FacultyId", "Name"),
                MaturaSubjects = db.MaturaSubjects,
                PointsMultipilers = db.PointsMultipilers.Include(ms => ms.MaturaSubject)
                    .Where(s => s.SpecializationId == model.Specialization.SpecializationId)
            });
        }
  

        // POST: Specializations/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Specialization specialization = db.Specializations.Find(id);
            db.Specializations.Remove(specialization);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
