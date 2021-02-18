using NexosBookApi.Controllers;
using NexosBookApi.Entities;
using NexosBookApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NexosBookApi.DAL
{
    public static class BooksDAL
    {
        public static string AddBook(DBNexosBook db, BooksEntities books)
        {
            if (books.Title == null || books.Gender == null)
            {
                return "Los datos no son correctos";
            }

            AuthorsController authorsController = new AuthorsController();
            EditorialsController editorialsController = new EditorialsController();

            var author = db.Authors.Where(x => x.Name == books.Author).FirstOrDefault();
            if (author == null)
                return "El autor no está registrado";

            var editorial = db.Editorials.Where(x => x.Name == books.Editorial).FirstOrDefault();
            if (editorial == null)
                return "La editorial no está registrada";

            if(editorial.CurrenBooks >= editorial.MaxBooks)
            {
                return "La editorial no tiene capacidad para mas libros";
            }

            Books bookUpdate = new Books();
            bookUpdate.Title = books.Title;
            bookUpdate.CreationDate = books.CreationDate;
            bookUpdate.Gender = books.Gender;
            bookUpdate.NumPages = books.NumPages;
            bookUpdate.Id_Author = author.Id_Author;
            bookUpdate.Id_Editorial = editorial.Id_Editorial;

            db.Books.Add(bookUpdate);
            db.SaveChanges();

            editorial.CurrenBooks += 1;
            editorialsController.PutEditorials(editorial.Id_Editorial, editorial);
            return "El libro fue registrado con exito";
        }

        public static List<BooksEntities> FinderBook(DBNexosBook db, BooksEntities booksEntities)
        {

            if(booksEntities.Author != null)
            {
                var ret = from B in db.Books
                          join E in db.Editorials on B.Id_Editorial equals E.Id_Editorial
                          join A in db.Authors on B.Id_Author equals A.Id_Author
                          where A.Name == booksEntities.Author
                          select new BooksEntities
                          {
                              Title = B.Title,
                              CreationDate = B.CreationDate,
                              Gender = B.Gender,
                              Author = A.Name,
                              Editorial = E.Name
                          };
                return ret.ToList();
            }
            if (booksEntities.Editorial != null)
            {
                var ret = from B in db.Books
                          join E in db.Editorials on B.Id_Editorial equals E.Id_Editorial
                          join A in db.Authors on B.Id_Author equals A.Id_Author
                          where E.Name == booksEntities.Editorial
                          select new BooksEntities
                          {
                              Title = B.Title,
                              CreationDate = B.CreationDate,
                              Gender = B.Gender,
                              Author = A.Name,
                              Editorial = E.Name
                          };
                return ret.ToList();
            }

            if (booksEntities.Title != null)
            {
                var ret = from B in db.Books
                          join E in db.Editorials on B.Id_Editorial equals E.Id_Editorial
                          join A in db.Authors on B.Id_Author equals A.Id_Author
                          where B.Title == booksEntities.Title
                          select new BooksEntities
                          {
                              Title = B.Title,
                              CreationDate = B.CreationDate,
                              Gender = B.Gender,
                              Author = A.Name,
                              Editorial = E.Name
                          };
                return ret.ToList();
            }

            if (booksEntities.CreationDate != null)
            {
                var ret = from B in db.Books
                          join E in db.Editorials on B.Id_Editorial equals E.Id_Editorial
                          join A in db.Authors on B.Id_Author equals A.Id_Author
                          where B.CreationDate == booksEntities.CreationDate
                          select new BooksEntities
                          {
                              Title = B.Title,
                              CreationDate = B.CreationDate,
                              Gender = B.Gender,
                              Author = A.Name,
                              Editorial = E.Name
                          };
                return ret.ToList();
            }
            return null;
        }
    }
}