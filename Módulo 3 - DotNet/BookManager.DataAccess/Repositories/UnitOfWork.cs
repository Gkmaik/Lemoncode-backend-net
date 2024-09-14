using BookManager.Domain.Abstractions.Repositories;

namespace BookManager.DataAccess.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly LibraryContext _context;

    public UnitOfWork(LibraryContext context)
    {
        _context = context;
    }

    public Task CommitAsync() =>
        _context.SaveChangesAsync();

    public void RollbackAsync()
    {
    }
}