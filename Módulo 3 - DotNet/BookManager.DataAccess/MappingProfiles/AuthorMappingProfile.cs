using AutoMapper;
using BookManager.Domain.Models;

using DalEntities = BookManager.Domain.Models;

namespace BookManager.DataAccess.MappingProfiles;

public class AuthorMappingProfile : Profile
{

    public AuthorMappingProfile()
    {
        CreateMap<DalEntities.Author, Author>()
            .ConstructUsing(s => new Author(s.Id, s.Name, s.LastName, s.Birth, s.CountryCode));
        CreateMap<Author, DalEntities.Author>();
    }
}