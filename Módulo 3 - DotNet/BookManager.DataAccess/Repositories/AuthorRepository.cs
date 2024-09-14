using AutoMapper;
using BookManager.Application.Exceptions;
using BookManager.Domain.Models;
using BookManager.Domain.Abstractions.Entities;
using BookManager.Domain.Abstractions.Repositories;

using Microsoft.EntityFrameworkCore;

using DalEntities = BookManager.Domain.Models;

namespace BookManager.DataAccess.Repositories;

public class AuthorRepository : IAuthorRepository
{

    private readonly LibraryContext _context;


    private readonly IMapper _mapper;

    public AuthorRepository(LibraryContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<Author> GetAuthor(int authorId)
    {
        var author = await _context.Author.SingleOrDefaultAsync(a => a.Id == authorId);
        if (author is null)
        {
            throw new EntityNotFoundException($"Unable to find an author with id {authorId}.");
        }

        return _mapper.Map<Author>(author);
    }

    public async Task<bool> AuthorExists(int authorId)
    {
        return await _context.Author.AnyAsync(a => a.Id == authorId);
    }

    public async Task<bool> AuthorsExist(int[] authorIds)
    {
        return (await _context.Author.CountAsync(a => authorIds.Contains(a.Id))) == authorIds.Length;
    }

    public Task<IIdentifiable> AddAuthor(Author author)
    {
        var dalAuthor = _mapper.Map<DalEntities.Author>(author);
        _context.Author.Add(dalAuthor);
        return Task.FromResult((IIdentifiable)dalAuthor);
    }

    public async Task EditAuthor(Author author)
    {
        var authorFromDb = await _context.Author.FindAsync(author.Id);
        if (authorFromDb is null)
        {
            throw new EntityNotFoundException($"The author with ID {author.Id} was not found.");
        }

        _mapper.Map(author, authorFromDb);
    }

    public async Task DeleteAuthor(int authorId)
    {
        var authorFromDb = await _context.Author.FindAsync(authorId);
        if (authorFromDb is null)
        {
            throw new EntityNotFoundException($"The author with ID {authorId} was not found.");
        }

        _context.Author.Remove(authorFromDb);
    }
}