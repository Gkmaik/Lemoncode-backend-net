namespace BookManager.Application.Dtos.Queries.Authors;

public class AuthorWithBookCountDto
{

    public int Id { get; set; }

    public required string Name { get; set; }

    public required string LastName { get; set; }

    public int BookCount { get; set; }

}