using BookManager.Application.Dtos.Commands.Authors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Application.Validators.Authors;

public class AuthorValidator : AbstractValidator<AuthorDto>
{
    public AuthorValidator()
    {
        RuleFor(p => p.FirstName)
            .NotNull()
            .NotEmpty()
            .Length(1, 100)
            .WithMessage("The author first name should contains between 1 and 100 characters.");

        RuleFor(p => p.LastName)
            .NotNull()
            .NotEmpty()
            .Length(1, 100)
            .WithMessage("The author first name should contains between 1 and 100 characters.");

        RuleFor(p => p.Birth)
            .NotEmpty()
            .WithMessage("Date of Birth is required.")
            .LessThan(DateTime.Now)
            .WithMessage("Date of Birth must be in the past.");


        RuleFor(p => p.CountryCode)
            .NotEmpty()
            .WithMessage("Country Code is required.")
            .Length(2)
            .WithMessage("Country Code must be exactly 2 characters.")
            .Must(BeAValidCountryCode)
            .WithMessage("Country Code is not a valid ISO 3166-1 alpha-2 code.");
    }

    private bool BeAValidCountryCode(string countryCode)
    {
        return CountryCodes.Iso3166Alpha2Codes.Contains(countryCode.ToUpper());
    }
}
