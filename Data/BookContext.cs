using BookApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BookApi.Data
{
    public class BookContext : DbContext
    {
        private static readonly string DBNAME = "BookAH";
        private static readonly int MAXROWSIZE = 40;
        public BookContext (DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Book>().Property(p => p.ISBN_10).HasMaxLength(MAXROWSIZE);
            builder.Entity<Book>().ToTable(DBNAME);
        }

        public DbSet<Book> Books { get; set; }
    }
}
