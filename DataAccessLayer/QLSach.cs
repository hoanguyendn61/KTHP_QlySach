using DataTransferObject;
using System;
using System.Data.Entity;
using System.Linq;
namespace DataAccessLayer
{
    public class QLSach : DbContext
    {
        public QLSach()
            : base("name=QLSach")
        {
            Database.SetInitializer<QLSach>(new DBInitializer());
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Author> Authors { get; set; }
    }
}