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
using NexosBookApi.Entities;
using NexosBookApi.Models;

namespace NexosBookApi.Controllers
{
    public class BooksController : ApiController
    {
        private DBNexosBook db = new DBNexosBook();

        // GET: api/Books
        public IQueryable<Books> GetBooks()
        {
            return db.Books;
        }

        // GET: api/Books/5
        [ResponseType(typeof(Books))]
        public IHttpActionResult GetBooks(long id)
        {
            Books books = db.Books.Find(id);
            if (books == null)
            {
                return NotFound();
            }

            return Ok(books);
        }

        // GET: api/Books/5
        [ResponseType(typeof(Books))]
        public IHttpActionResult GetFinderBooks(BooksEntities booksEntities)
        {
            using (DBNexosBook db = new DBNexosBook())
            {
               var a = BooksDAL.FinderBook(db, booksEntities);
               booksEntities = a.FirstOrDefault();
            }
            return Ok(booksEntities);
        }

        // PUT: api/Books/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBooks(long id, Books books)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != books.Id_Boock)
            {
                return BadRequest();
            }

            db.Entry(books).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BooksExists(id))
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

        // POST: api/Books
        [ResponseType(typeof(Books))]
        public string PostBooks(BooksEntities books)
        {
            string response;
            try
            {
                using (DBNexosBook db = new DBNexosBook())
                {
                    response = BooksDAL.AddBook(db, books);
                }

            }
            catch (Exception)
            {
                return "No se pudo hacer el registro, consulte a su administrador";
                throw;
            }
            return response;

        }

        // DELETE: api/Books/5
        [ResponseType(typeof(Books))]
        public IHttpActionResult DeleteBooks(long id)
        {
            Books books = db.Books.Find(id);
            if (books == null)
            {
                return NotFound();
            }

            db.Books.Remove(books);
            db.SaveChanges();

            return Ok(books);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BooksExists(long id)
        {
            return db.Books.Count(e => e.Id_Boock == id) > 0;
        }
    }
}