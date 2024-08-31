using BookManager.DataAccess;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BookManager.MigrationClasses;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<LibraryContext>
{
    public LibraryContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .AddUserSecrets(typeof(Program).Assembly)
            .Build();
        var builder = new DbContextOptionsBuilder<LibraryContext>();
        var connectionString = configuration.GetConnectionString("DefaultConnectionString");
        builder.UseSqlServer(connectionString);
        return new LibraryContext(builder.Options);
    }
}
