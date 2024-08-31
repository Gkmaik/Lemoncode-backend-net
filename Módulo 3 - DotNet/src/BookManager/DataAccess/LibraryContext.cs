using BookManager.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BookManager.DataAccess
{
    public class LibraryContext : DbContext
    {
        public DbSet<Author> Author { get; set; }
        public DbSet<Book> Book { get; set; }

        public LibraryContext(DbContextOptions<LibraryContext> options)
            : base(options)
        {
        }
    }
}
