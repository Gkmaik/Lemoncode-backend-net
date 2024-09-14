using BookManager.Application.Dtos.Commands.Books;
using FluentValidation.Results;


namespace BookManager.Application.Abstractions.Services;

public interface IBookService
{
    Task<(ValidationResult ValidationResult, int? BookId)> AddBook(BookDto book);
    Task<ValidationResult> EditBook(BookDto author);


}
