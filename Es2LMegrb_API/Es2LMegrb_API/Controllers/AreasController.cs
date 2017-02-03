﻿using System;
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
    public class AreasController : ApiController
    {
        private DBContext db = new DBContext();

        // GET: api/Areas
        public IQueryable<Area> GetAreas()
        {
            return db.Areas;
        }

        // GET: api/Areas/5
        [ResponseType(typeof(Area))]
        public IHttpActionResult GetArea(long id)
        {
            Area area = db.Areas.Find(id);
            if (area == null)
            {
                return NotFound();
            }

            return Ok(area);
        }

        // PUT: api/Areas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutArea(long id, Area area)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != area.AreaID)
            {
                return BadRequest();
            }

            db.Entry(area).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AreaExists(id))
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

        // POST: api/Areas
        [ResponseType(typeof(Area))]
        public IHttpActionResult PostArea(Area area)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Areas.Add(area);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = area.AreaID }, area);
        }

        // DELETE: api/Areas/5
        [ResponseType(typeof(Area))]
        public IHttpActionResult DeleteArea(long id)
        {
            Area area = db.Areas.Find(id);
            if (area == null)
            {
                return NotFound();
            }

            db.Areas.Remove(area);
            db.SaveChanges();

            return Ok(area);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AreaExists(long id)
        {
            return db.Areas.Count(e => e.AreaID == id) > 0;
        }
    }
}