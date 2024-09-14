using BookManager.Domain.Abstractions.Entities;

namespace BookManager.DataAccess.Entities;

public class Author : IIdentifiable
{
    public int Id { get; set; }

    public required string Name { get; set; }

    public required string LastName { get; set; }
    public DateTime Birth { get; set; }
    public string? CountryCode { get; set; }

    public required ICollection<Book> Books { get; set; }
}