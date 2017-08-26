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
using ch_hello_world.DAL;
using ch_hello_world.Models;

namespace ch_hello_world.Controllers
{
    public class GetNamesController : ApiController
    {
        private Users db = new Users();

        // GET: api/GetNames
        /// <summary>
        /// Returns all names from the database
        /// </summary>
        public IQueryable<Name> GetName()
        {
            return db.Name;
        }

        // GET: api/GetNames/5
        /// <summary>
        /// Returns only a name based on id
        /// </summary>
        [ResponseType(typeof(Name))]
        public IHttpActionResult GetName(int id)
        {
            Name name = db.Name.Find(id);
            if (name == null)
            {
                return NotFound();
            }

            return Ok(name);
        }

        // PUT: api/GetNames/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutName(int id, Name name)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != name.ID)
            {
                return BadRequest();
            }

            db.Entry(name).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NameExists(id))
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

        // POST: api/GetNames
        [ResponseType(typeof(Name))]
        public IHttpActionResult PostName(Name name)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Name.Add(name);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = name.ID }, name);
        }

        // DELETE: api/GetNames/5
        [ResponseType(typeof(Name))]
        public IHttpActionResult DeleteName(int id)
        {
            Name name = db.Name.Find(id);
            if (name == null)
            {
                return NotFound();
            }

            db.Name.Remove(name);
            db.SaveChanges();

            return Ok(name);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NameExists(int id)
        {
            return db.Name.Count(e => e.ID == id) > 0;
        }
    }
}