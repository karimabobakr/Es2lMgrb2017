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
    public class SectionsController : ApiController
    {
        private DBContext db = new DBContext();

        // GET: api/Sections
        public IQueryable<Section> GetSections()
        {
            return db.Sections;
        }

        // GET: api/Sections/5
        [ResponseType(typeof(Section))]
        public IHttpActionResult GetSection(int id)
        {
            Section section = db.Sections.Find(id);
            if (section == null)
            {
                return NotFound();
            }

            return Ok(section);
        }

        // PUT: api/Sections/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSection(int id, Section section)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != section.SectionID)
            {
                return BadRequest();
            }

            db.Entry(section).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SectionExists(id))
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

        // POST: api/Sections
        [ResponseType(typeof(Section))]
        public IHttpActionResult PostSection(Section section)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Sections.Add(section);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = section.SectionID }, section);
        }

        // DELETE: api/Sections/5
        [ResponseType(typeof(Section))]
        public IHttpActionResult DeleteSection(int id)
        {
            Section section = db.Sections.Find(id);
            if (section == null)
            {
                return NotFound();
            }

            db.Sections.Remove(section);
            db.SaveChanges();

            return Ok(section);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SectionExists(int id)
        {
            return db.Sections.Count(e => e.SectionID == id) > 0;
        }
    }
}