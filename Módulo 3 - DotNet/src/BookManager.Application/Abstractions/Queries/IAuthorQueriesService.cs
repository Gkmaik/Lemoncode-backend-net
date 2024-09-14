using BookManager.Application.Dtos.Queries.Authors;

namespace BookManager.Application.Abstractions.Queries;

public interface IAuthorQueriesService
{

    Task<List<AuthorWithBookCountDto>> GetAuthors();
    Task<AuthorWithBookCountDto> GetAuthorById(int authorId);
}