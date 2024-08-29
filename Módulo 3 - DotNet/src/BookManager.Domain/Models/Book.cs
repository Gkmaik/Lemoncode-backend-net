namespace BookManager.Domain.Models;

public class Book : Entity
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public DateTime PublishedOn { get; set; }
    public string? Description { get; set; }

    public DateTime Created { get; set; }

    public DateTime Updated { get; private set; }

    public ICollection<int> Authors { get; private set; }

    public void UpdateTitle(string title)
    {
        this.Title = title;
        UpdateUpdatedDate();
        EnsureStateIsValid();
    }

    public void UpdateAuthors(ICollection<int> authors)
    {
        this.Authors = authors;
        UpdateUpdatedDate();
        EnsureStateIsValid();
    }

    public void UpdateDescription(string description)
    {
        this.Description = description;
        UpdateUpdatedDate();
        EnsureStateIsValid();
    }

    public Book(int id, string title, string description, ICollection<int> authors)
    {
        this.Id = id;
        this.Title = title;
        this.Description = description;
        this.Created = DateTime.UtcNow;
        UpdateUpdatedDate();
        this.Authors = authors;
        EnsureStateIsValid();
    }

    private void UpdateUpdatedDate()
    {
        this.Updated = DateTime.UtcNow;
    }

    protected override void EnsureStateIsValid()
    {
        if (string.IsNullOrWhiteSpace(Title))
        {
            AddValidationError("The title is mandatory.");
        }

        if (!Authors.Any())
        {
            AddValidationError("The book should have at least one author.");
        }

        Validate();
    }
}
