using BookManager.Models;
using Microsoft.EntityFrameworkCore;

namespace BookManager.DataAccess
{
    public class LibraryContext : DbContext
    {
        public DbSet<Author> Author { get; set; }
        public DbSet<Book> Book { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "BookManager", "library.db");
            var dbDir = Path.GetDirectoryName(dbPath);
            if (!Directory.Exists(dbDir))
            {
                Directory.CreateDirectory(dbDir!);
            }
            optionsBuilder.UseSqlite($"Data Source={dbPath}");
        }
    }
}
