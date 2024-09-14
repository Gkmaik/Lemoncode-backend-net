using BookManager.Domain.Abstractions.Entities;

namespace BookManager.DataAccess.Entities;

public class Book : IIdentifiable
{

    public int Id { get; set; }

    public required string Title { get; set; }

    public required string Description { get; set; }

    public DateTime PublishedOn { get; set; }

    public required ICollection<Author> Authors { get; set; }


}
