using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NexosBookApi.Entities
{
    public class BooksEntities
    {
        public long Id_Boock { get; set; }

        public string Title { get; set; }

        public DateTime? CreationDate { get; set; }

        public string Gender { get; set; }

        public string NumPages { get; set; }

        public string Editorial { get; set; }

        public string Author { get; set; }
    }
}