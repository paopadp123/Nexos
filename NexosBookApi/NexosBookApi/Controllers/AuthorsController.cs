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
using NexosBookApi.Models;

namespace NexosBookApi.Controllers
{
    public class AuthorsController : ApiController
    {
        private DBNexosBook db = new DBNexosBook();

        // GET: api/Authors
        public IQueryable<Authors> GetAuthors()
        {
            return db.Authors;
        }

        // GET: api/Authors/5
        [ResponseType(typeof(Authors))]
        public IHttpActionResult GetAuthors(long id)
        {
            Authors authors = db.Authors.Find(id);
            if (authors == null)
            {
                return NotFound();
            }

            return Ok(authors);
        }

        // PUT: api/Authors/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAuthors(long id, Authors authors)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != authors.Id_Author)
            {
                return BadRequest();
            }

            db.Entry(authors).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuthorsExists(id))
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

        // POST: api/Authors
        [ResponseType(typeof(Authors))]
        public IHttpActionResult PostAuthors(Authors authors)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Authors.Add(authors);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = authors.Id_Author }, authors);
        }

        // DELETE: api/Authors/5
        [ResponseType(typeof(Authors))]
        public IHttpActionResult DeleteAuthors(long id)
        {
            Authors authors = db.Authors.Find(id);
            if (authors == null)
            {
                return NotFound();
            }

            db.Authors.Remove(authors);
            db.SaveChanges();

            return Ok(authors);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AuthorsExists(long id)
        {
            return db.Authors.Count(e => e.Id_Author == id) > 0;
        }
    }
}