using BookManager.Domain.Exceptions;

namespace BookManager.Domain;

public abstract record class ValueObject
{

    private List<string> _validationErrors = new List<string>();

    public void Validate()
    {
        if (!_validationErrors.Any())
        {
            return;
        }

        var ex = new InvalidEntityStateException(_validationErrors);
        _validationErrors.Clear();
        throw ex;
    }

    protected void AddValidationError(string errorMessage) => _validationErrors.Add(errorMessage);
}