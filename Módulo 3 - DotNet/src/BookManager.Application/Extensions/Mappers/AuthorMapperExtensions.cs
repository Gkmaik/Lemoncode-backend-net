using BookManager.Application.Dtos.Commands.Authors;
using BookManager.Domain.Models;

namespace BookManager.Application.Extensions.Mappers;

internal static class AuthorMapperExtensions
{

    public static AuthorDto ConverToDto(this Author author)
    {
        return new AuthorDto
        {            
            Name = author.Name,
            LastName = author.LastName,
            Birth = author.Birth,
            CountryCode = author.CountryCode
        };
    }
        

    public static Author ConvertToDomainEntity(this AuthorDto authorDto)
    {
        return new Author(
        
            id: authorDto.Id,
            firstName: authorDto.Name,
            lastName: authorDto.LastName,
            birth: authorDto.Birth,
            countryCode: authorDto.CountryCode);
        
    }
}