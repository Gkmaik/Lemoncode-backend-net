using FluentValidation.Results;
using BookManager.Application.Dtos.Commands.Books;
using BookManager.Application.Dtos.Commands.Authors;


namespace BookManager.Application.Abstractions.Services;

public interface IBookService
{
    Task<(ValidationResult ValidationResult, int? BookId)> AddBook(BookDto book);
    Task<ValidationResult> EditBook(BookDto author);


}
