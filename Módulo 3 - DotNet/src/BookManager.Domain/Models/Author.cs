namespace BookManager.Domain.Models;

public class Author : Entity
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string LastName { get; private set; }
    public DateTime Birth { get; set; }
    public string? CountryCode { get; set; }


    public Author(int id, string firstName, string lastName, DateTime birth, string? countryCode)
    {
        this.Id = id;
        this.Name = firstName;
        this.LastName = lastName;
        this.Birth = birth;
        this.CountryCode = countryCode;
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

    public void UpdateBirthDate(DateTime birth)
    {
        this.Birth = birth;
        EnsureStateIsValid();
    }

    public void UpdateCountryCode(string countryCode)
    {
        this.CountryCode = countryCode;
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

        if (Birth >= DateTime.Now)
        {
            AddValidationError("Birth date must be a date in the past");
        }

        if (string.IsNullOrWhiteSpace(CountryCode) || CountryCode.Length != 2)
        {
            AddValidationError("Country Code must contains 2 characters, and cannot be empty.");
        }

        Validate();
    }

}
