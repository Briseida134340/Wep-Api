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
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class User1Controller : ApiController
    {
        private PersonaLineaEntities1 db = new PersonaLineaEntities1();

        // GET: api/User1
        public IQueryable<User1> GetUser1()
        {
            return db.User1;
        }

        // GET: api/User1/5
        [ResponseType(typeof(User1))]
        public IHttpActionResult GetUser1(int id)
        {
            User1 user1 = db.User1.Find(id);
            if (user1 == null)
            {
                return NotFound();
            }

            return Ok(user1);
        }

        // PUT: api/User1/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUser1(int id, User1 user1)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user1.Id)
            {
                return BadRequest();
            }

            db.Entry(user1).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!User1Exists(id))
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

        // POST: api/User1
        [ResponseType(typeof(User1))]
        public IHttpActionResult PostUser1(User1 user1)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.User1.Add(user1);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = user1.Id }, user1);
        }

        // DELETE: api/User1/5
        [ResponseType(typeof(User1))]
        public IHttpActionResult DeleteUser1(int id)
        {
            User1 user1 = db.User1.Find(id);
            if (user1 == null)
            {
                return NotFound();
            }

            db.User1.Remove(user1);
            db.SaveChanges();

            return Ok(user1);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool User1Exists(int id)
        {
            return db.User1.Count(e => e.Id == id) > 0;
        }
    }
}