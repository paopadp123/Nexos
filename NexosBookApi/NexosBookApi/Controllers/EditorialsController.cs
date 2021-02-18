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
using NexosBookApi.DAL;
using NexosBookApi.Models;

namespace NexosBookApi.Controllers
{
    public class EditorialsController : ApiController
    {
        private DBNexosBook db = new DBNexosBook();

        // GET: api/Editorials
        public IQueryable<Editorials> GetEditorials()
        {
            return db.Editorials;
        }

        // GET: api/Editorials/5
        [ResponseType(typeof(Editorials))]
        public IHttpActionResult GetEditorials(long id)
        {
            Editorials editorials = db.Editorials.Find(id);
            if (editorials == null)
            {
                return NotFound();
            }

            return Ok(editorials);
        }

        // PUT: api/Editorials/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEditorials(long id, Editorials editorials)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != editorials.Id_Editorial)
            {
                return BadRequest();
            }

            db.Entry(editorials).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EditorialsExists(id))
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

        // POST: api/Editorials
        [ResponseType(typeof(Editorials))]
        public string PostEditorials(Editorials editorials)
        {
            string response;
            try
            {
                using (DBNexosBook db = new DBNexosBook())
                {
                    response = EditorialsDAL.AddEditorial(db, editorials);
                }
            }
            catch (Exception)
            {
                return "No se pudo hacer el registro, consulte a su administrador";
                throw;
            }
            
            return response;
        }

        private bool EditorialsExists(long id)
        {
            return db.Editorials.Count(e => e.Id_Editorial == id) > 0;
        }
    }
}