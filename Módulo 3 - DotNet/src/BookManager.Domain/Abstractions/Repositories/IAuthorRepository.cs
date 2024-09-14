using BookManager.Domain.Abstractions.Entities;
using BookManager.Domain.Models;

namespace BookManager.Domain.Abstractions.Repositories;

public interface IAuthorRepository
{

    Task<Author> GetAuthor(int authorId);

    Task<bool> AuthorExists(int authorId);

    Task<bool> AuthorsExist(int[] authorIds);

    Task<IIdentifiable> AddAuthor(Author author);

    Task EditAuthor(Author author);

    Task DeleteAuthor(int authorId);
}