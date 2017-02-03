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
using System.Web.Http.Cors;
using System.Reflection;

namespace Es2LMegrb_API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class CategoriesController : ApiController
    {
        private DBContext db = new DBContext();

        [HttpGet]
        public string sayHello()
        {

            return "hello";
        }

        // GET: api/Categories
        public IQueryable<Category> GetCategories()
        {
            return db.Categories;
        }

        // GET: api/Categories/5
        [ResponseType(typeof(Category))]
        public IHttpActionResult GetCategory(int id)
        {
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        // PUT: api/Categories/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCategory(int id, Category category)
        {

            category.CatagoryID = id;
            var retrievedCatagory = GetCategory(id);
            
            
            //PropertyInfo [] keys = retrievedCatagory.GetType().GetProperties();
            //foreach (var element  in keys)
            //{
            //    string  keyName = element.Name;
            //    var name = (element.GetValue(retrievedCatagory, null));
            //    if (category.GetType().GetProperty(element.ToString()) != null)
            //    {

            //    }

            //    // Do something with propValue
            //}
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != category.CatagoryID)
            {
                return BadRequest();
            }

            db.Entry(retrievedCatagory).State = EntityState.Detached;
            db.Entry(category).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = category.CatagoryID }, category);
            // return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Categories
        [ResponseType(typeof(Category))]
        public IHttpActionResult PostCategory(Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Categories.Add(category);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = category.CatagoryID }, category);
        }

        // DELETE: api/Categories/5
        [ResponseType(typeof(Category))]
        public IHttpActionResult DeleteCategory(int id)
        {
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }

            db.Categories.Remove(category);
            db.SaveChanges();

            return Ok(category);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CategoryExists(int id)
        {
            return db.Categories.Count(e => e.CatagoryID == id) > 0;
        }
    }
}