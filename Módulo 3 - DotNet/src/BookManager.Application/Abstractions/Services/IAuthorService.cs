using FluentValidation.Results;
using BookManager.Application.Dtos.Commands.Authors;


namespace BookManager.Application.Abstractions.Services;

public interface IAuthorService
{
    Task<(ValidationResult ValidationResult, int? AuthorId)> AddAuthor(AuthorDto author);
}
