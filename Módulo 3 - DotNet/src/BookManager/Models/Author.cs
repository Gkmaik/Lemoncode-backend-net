namespace BookManager.Models
{
    public class Author
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string LastName { get; set; }
        public DateTime Birth { get; set; }
        public string? CountryCode { get; set; }
        public required List<Book> Books { get; set; }

    }
}
