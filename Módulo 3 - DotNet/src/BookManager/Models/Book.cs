namespace BookManager.Models
{
    public class Book
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public DateTime PublishedOn { get; set; }
        public string? Description { get; set; }

    }
}
