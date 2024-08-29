using BookManager.Application.Dtos.Commands.Authors;
using System.ComponentModel.DataAnnotations;


namespace BookManager.Application.Abstractions.Services;

public interface IAuthorService
{
    Task<(ValidationResult ValidationResult, int? AuthorId)> AddAuthor(AuthorDto author);
}
