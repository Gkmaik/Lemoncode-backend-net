﻿using System.ComponentModel.DataAnnotations;

namespace BookManager.Application.Dtos.Commands.Authors;

public class AuthorDto
{
    public int Id { get; set; }

    [Required(ErrorMessage = "The name is required.")]
    [StringLength(100, ErrorMessage = "The name must contains 100 characters maximum.")]
    public required string Name { get; set; }

    [Required(ErrorMessage = "The last name is required.")]
    [StringLength(100, ErrorMessage = "The last name must contains 100 characters maximum.")]
    public required string LastName { get; set; }

    [Required(ErrorMessage = "Date format must be MM/dd/yyyy.")]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
    public DateTime Birth { get; set; }

    [Required(ErrorMessage = "Country Code is required.")]
    [StringLength(2, MinimumLength = 2, ErrorMessage = "CountryCode must be a 2-character ISO 3166-1 alpha-2 code.")]
    public string? CountryCode { get; set; }
}
