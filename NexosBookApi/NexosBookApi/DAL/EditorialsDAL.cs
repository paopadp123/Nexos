using NexosBookApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static System.Net.WebRequestMethods;

namespace NexosBookApi.DAL
{
    public static class EditorialsDAL
    {
        public static string AddEditorial(DBNexosBook db, Editorials editorial)
        {
            if (editorial.Name == null || editorial.AddressMail == null)
            {
                return "Los datos no son correctos";
            }

            if (editorial.MaxBooks == 0)
            {
                editorial.MaxBooks = -1;
            }
            editorial.CurrenBooks = 0;
            db.Editorials.Add(editorial);
            db.SaveChanges();
            return "Editor registrado con exito";
        }
    }
}