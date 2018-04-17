using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RSystem.DAL;
using RSystem.Models;

namespace RSystem.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class FacultiesController : Controller
    {
        private ApplicationDbContext db=new ApplicationDbContext();

        public ActionResult Index()
        {
            return View(db.Faculties.OrderBy(n=>n.Name));
        }

        [HttpPost]
        public ActionResult Index(Faculty faculty)
        {
            if (string.IsNullOrWhiteSpace(faculty.Name))
            {
                ViewBag.Validation = "Wydział nie został dodany ponieważ nazwa wydziału nie została ustawiona";
                return View(db.Faculties.OrderBy(n => n.Name));
            }
            if (string.IsNullOrWhiteSpace(faculty.Abbrevation))
            {
                ViewBag.Validation = "Wydział nie został dodany ponieważ skrót wydziału nie został ustawiony";
                return View(db.Faculties.OrderBy(n => n.Name));
            }

            db.Faculties.AddOrUpdate(faculty);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int?id)
        {            
            var toRemove = id!=null
                ?db.Faculties.FirstOrDefault(f => f.FacultyId == id)
                :null;

            if (toRemove == null)
                return HttpNotFound();

            db.Faculties.Remove(toRemove);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}