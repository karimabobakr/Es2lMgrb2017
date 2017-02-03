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
    public class DestinationesController : ApiController
    {
        private DBContext db = new DBContext();

        // GET: api/Destinationes
        public IQueryable<Destinatione> GetDestinationes()
        {
            return db.Destinationes;
        }

        // GET: api/Destinationes/5
        [ResponseType(typeof(Destinatione))]
        public IHttpActionResult GetDestinatione(long id)
        {
            Destinatione destinatione = db.Destinationes.Find(id);
            if (destinatione == null)
            {
                return NotFound();
            }

            return Ok(destinatione);
        }

        // PUT: api/Destinationes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDestinatione(long id, Destinatione destinatione)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != destinatione.DestinationID)
            {
                return BadRequest();
            }

            db.Entry(destinatione).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DestinationeExists(id))
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

        // POST: api/Destinationes
        [ResponseType(typeof(Destinatione))]
        public IHttpActionResult PostDestinatione(Destinatione destinatione)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Destinationes.Add(destinatione);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = destinatione.DestinationID }, destinatione);
        }

        // DELETE: api/Destinationes/5
        [ResponseType(typeof(Destinatione))]
        public IHttpActionResult DeleteDestinatione(long id)
        {
            Destinatione destinatione = db.Destinationes.Find(id);
            if (destinatione == null)
            {
                return NotFound();
            }

            db.Destinationes.Remove(destinatione);
            db.SaveChanges();

            return Ok(destinatione);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DestinationeExists(long id)
        {
            return db.Destinationes.Count(e => e.DestinationID == id) > 0;
        }
    }
}