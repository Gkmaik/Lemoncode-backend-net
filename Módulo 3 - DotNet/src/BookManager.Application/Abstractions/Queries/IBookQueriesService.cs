using BookManager.Application.Dtos.Queries.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Application.Abstractions.Queries;

public interface IBookQueriesService
{
    Task<List<BookCountDto>> GetBooks();
    Task<BookCountDto> GetBookById(int bookId);
}
