using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Web.Http;
using RSystem.DAL;

namespace RSystem.Api
{

    [Authorize]
    public class SpecializationsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [HttpDelete]
        public IHttpActionResult DeleteMaturaSubejct(int? id)
        {
            if (id == null)
                return BadRequest();
            var toRemove = db.PointsMultipilers.FirstOrDefault(i => i.PointsMultipilerId == id);
            if (toRemove != null)
            {
                db.PointsMultipilers.Remove(toRemove);
                db.SaveChanges();
                return Ok();
            }
            return NotFound();
        }
    }
}
