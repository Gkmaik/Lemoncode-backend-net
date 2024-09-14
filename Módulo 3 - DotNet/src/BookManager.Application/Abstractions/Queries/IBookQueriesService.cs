using BookManager.Application.Dtos.Queries.Books;

namespace BookManager.Application.Abstractions.Queries;

public interface IBookQueriesService
{
    Task<List<BookCountDto>> GetBooks();
    Task<BookCountDto> GetBookById(int bookId);
}
