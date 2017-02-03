using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Es2LMegrb_API.Models;

namespace Es2LMegrb_API.Controllers
{
    public class OpeningHoursController : ApiController
    {
        private DBContext db = new DBContext();

        // GET: api/OpeningHours
        public IQueryable<OpeningHour> GetOpeningHours()
        {
            return db.OpeningHours;
        }

        // GET: api/OpeningHours/5
        [ResponseType(typeof(OpeningHour))]
        public IHttpActionResult GetOpeningHour(long id)
        {
            OpeningHour openingHour = db.OpeningHours.Find(id);
            if (openingHour == null)
            {
                return NotFound();
            }

            return Ok(openingHour);
        }

        // PUT: api/OpeningHours/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutOpeningHour(long id, OpeningHour openingHour)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != openingHour.Destination_ID)
            {
                return BadRequest();
            }

            db.Entry(openingHour).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OpeningHourExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/OpeningHours
        [ResponseType(typeof(OpeningHour))]
        public IHttpActionResult PostOpeningHour(OpeningHour openingHour)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.OpeningHours.Add(openingHour);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (OpeningHourExists(openingHour.Destination_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = openingHour.Destination_ID }, openingHour);
        }

        // DELETE: api/OpeningHours/5
        [ResponseType(typeof(OpeningHour))]
        public IHttpActionResult DeleteOpeningHour(long id)
        {
            OpeningHour openingHour = db.OpeningHours.Find(id);
            if (openingHour == null)
            {
                return NotFound();
            }

            db.OpeningHours.Remove(openingHour);
            db.SaveChanges();

            return Ok(openingHour);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OpeningHourExists(long id)
        {
            return db.OpeningHours.Count(e => e.Destination_ID == id) > 0;
        }
    }
}