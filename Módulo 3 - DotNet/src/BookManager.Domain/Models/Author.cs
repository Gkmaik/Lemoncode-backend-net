namespace BookManager.Domain.Models
{
    public class Author : Entity
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string LastName { get; set; }
        public DateTime Birth { get; set; }
        public string? CountryCode { get; set; }
        public required List<Book> Books { get; set; }

        public Author(int id, string firstName, string lastName)
        {
            this.Id = id;
            this.Name = firstName;
            this.LastName = lastName;
            EnsureStateIsValid();
        }

        public void UPdateFirstName(string firstName)
        {
            this.Name = firstName;
            EnsureStateIsValid();
        }

        public void UpdateLastName(string lastName)
        {
            this.LastName = lastName;
            EnsureStateIsValid();
        }

        protected override void EnsureStateIsValid()
        {
            if (string.IsNullOrWhiteSpace(Name) || Name.Length > 100)
            {
                AddValidationError("First name should contains between 1 and 100 characters, and cannot be empty.");
            }

            if (string.IsNullOrWhiteSpace(LastName) || LastName.Length > 100)
            {
                AddValidationError("Last name should contains between 1 and 100 characters, and cannot be empty.");
            }

            Validate();
        }

    }
}
