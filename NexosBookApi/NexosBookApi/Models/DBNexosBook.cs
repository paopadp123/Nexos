using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace NexosBookApi.Models
{
    public partial class DBNexosBook : DbContext
    {
        public DBNexosBook()
            : base("name=DBNexosBook5")
        {
        }

        public virtual DbSet<Authors> Authors { get; set; }
        public virtual DbSet<Books> Books { get; set; }
        public virtual DbSet<Editorials> Editorials { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Authors>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Authors>()
                .Property(e => e.Origin)
                .IsUnicode(false);

            modelBuilder.Entity<Authors>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Books>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<Books>()
                .Property(e => e.Gender)
                .IsUnicode(false);

            modelBuilder.Entity<Books>()
                .Property(e => e.NumPages)
                .IsUnicode(false);

            modelBuilder.Entity<Books>()
                .HasOptional(e => e.Books1)
                .WithRequired(e => e.Books2);

            modelBuilder.Entity<Editorials>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Editorials>()
                .Property(e => e.AddressMail)
                .IsUnicode(false);

            modelBuilder.Entity<Editorials>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Editorials>()
                .Property(e => e.Email)
                .IsUnicode(false);
        }
    }
}
